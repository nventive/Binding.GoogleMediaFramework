using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace GoogleMediaFramework
{
	public class GMFIMAAdService : GMFAdService, IGMFPlayerOverlayViewControllerDelegate
	{
		private GMFContentPlayhead _contentPlayhead;

		private IMAAdsLoader adsLoader;
		private IMAAdsManager adsManager;
		private IMAAdDisplayContainer adDisplayContainer;

		private NSObject _willEnterForegroundObserver;

		private bool _hasVideoPlayerControl;

		public GMFIMAAdService(GMFPlayerViewController videoPlayerController) : base(videoPlayerController)
		{
			adsLoader = new IMAAdsLoader(CreateIMASettings());
			adsLoader.WeakDelegate = this;
		}

		public void RequestAdsWithRequest(string request)
		{
			var view = new UIView(VideoPlayerController.View.Bounds);
			VideoPlayerController.SetAboveRenderingView(view);
			adDisplayContainer = new IMAAdDisplayContainer(view, null);
			_contentPlayhead = new GMFContentPlayhead(VideoPlayerController);
			
			IMAAdsRequest adsRequest = new IMAAdsRequest(request, adDisplayContainer, _contentPlayhead, null);
			adsLoader.RequestAdsWithRequest(adsRequest);
		}

		private void ResumeAdOnForeground(NSNotification n)
		{
			if (_hasVideoPlayerControl)
			{
				adsManager?.Resume();
			}
		}
		
		private IMASettings CreateIMASettings()
		{
			var settings = new IMASettings();
			settings.Language = NSLocale.PreferredLanguages[0];
			settings.PlayerType = "google/gmf-ios";
			settings.PlayerVersion = "1.0.0";

			return settings;
		}

		#region AdsLoaderDelegate
			[Export("adsLoader:adsLoadedWithData:")]
			public void AdsLoadedWithData(IMAAdsLoader adsLoader, IMAAdsLoadedData adsLoadedData)
			{
				adsManager = adsLoadedData.AdsManager;
				// GMFContentPlayhead handles listening for time updates from the video player and passing those
				// to the AdsManager.

				adsManager.InitializeWithAdsRenderingSettings(null);

				adsManager.WeakDelegate = this;
				_willEnterForegroundObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIApplication.WillEnterForegroundNotification, ResumeAdOnForeground);
				adsManager.Start();

			}

			[Export("adsLoader:failedWithErrorData:")]
			public void FailedWithErrorData(IMAAdsLoader adsLoader, IMAAdLoadingErrorData adErrorData)
			{
				System.Diagnostics.Debug.WriteLine($"Ad loading error {adErrorData.AdError.Message}");

				VideoPlayerController?.Play();
			}
			#endregion

		
		#region AdsManagerDelegate
			private void TakeControlOfVideoPlayer()
			{
				var playerViewController = VideoPlayerController;
				var overlayView = playerViewController.PlayerOverlayView;
				var overlayViewController =
					VideoPlayerController.VideoPlayerOverlayViewController;


				//TODO
				overlayViewController.IsAdDisplayed = true;
				overlayView.HideSpinner();

				overlayView.DisableTopBar();
				_hasVideoPlayerControl = true;
				VideoPlayerController.Pause();
				overlayView.SetPlayerBarVisible(false);
				VideoPlayerController.SetVideoPlayerOverlayDelegate(new PlayerControlsViewDelegate(this));
			}

		[Export("adsManager:didReceiveAdEvent:")]
		public void DidReceiveAdEvent(IMAAdsManager adsManager, IMAAdEvent adEvent)
		{
			var eventType = adEvent.Type;
			System.Diagnostics.Debug.WriteLine($"** Ad Event **: {AdEventAsString(adEvent.Type)}");

			switch (eventType)
			{
				case IMAAdEventType.Loaded:
					VideoPlayerController.PlayerOverlayView.SetTotalTime(adEvent.Ad.Duration);
					break;
				case IMAAdEventType.Started:
				case IMAAdEventType.Resume:
					VideoPlayerController.PlayerOverlayView.DisableSeekbarInteraction();
					VideoPlayerController.PlayerOverlayView.ShowPauseButton();
					//ShowPlayerControls();
					break;
				case IMAAdEventType.Pause:
					VideoPlayerController.PlayerOverlayView.ShowPlayButton();
					//ShowPlayerControls();
					break;
				case IMAAdEventType.AllAdsCompleted:
					RelinquishControlToVideoPlayer();
					DestroyAdsManager();
					break;
				default:
					break;
			}
		}

		// @required -(void)adsManager:(IMAAdsManager *)adsManager didReceiveAdError:(IMAAdError *)error;
		[Export("adsManager:didReceiveAdError:")]
		public void DidReceiveAdError(IMAAdsManager adsManager, IMAAdError error)
		{
			RelinquishControlToVideoPlayer();
			VideoPlayerController.Play();
		}

		// @required -(void)adsManagerDidRequestContentPause:(IMAAdsManager *)adsManager;
		[Export("adsManagerDidRequestContentPause:")]
		public void DidRequestContentPause(IMAAdsManager adsManager)
		{
			// IMA SDK wants control of the player, so pause and take over delegate from video controls.
			TakeControlOfVideoPlayer();
		}

		// @required -(void)adsManagerDidRequestContentResume:(IMAAdsManager *)adsManager;
		[Export("adsManagerDidRequestContentResume:")]
		public void DidRequestContentResume(IMAAdsManager adsManager)
		{
			VideoPlayerController.SetControlsVisibility(visible: true, animated: true);
			RelinquishControlToVideoPlayer();
			VideoPlayerController.Play();
		}

		// @optional -(void)adsManager:(IMAAdsManager *)adsManager adDidProgressToTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)totalTime;
		[Export("adsManager:adDidProgressToTime:totalTime:")]
		public void AdDidProgressToTime(IMAAdsManager adsManager, double mediaTime, double totalTime)
		{
			VideoPlayerController.PlayerOverlayView.SetMediaTime(mediaTime);
		}
		#endregion

		private void ShowPlayerControls()
		{
			var overlayViewController = VideoPlayerController.VideoPlayerOverlayViewController;
			overlayViewController.ShowPlayerControlsAnimated(true);
		}

		private void RelinquishControlToVideoPlayer()
		{
			var playerViewController = VideoPlayerController;
			var overlayView = playerViewController.PlayerOverlayView;
			var overlayViewController = VideoPlayerController.VideoPlayerOverlayViewController;

			overlayViewController.IsAdDisplayed = false;
			overlayView.EnableSeekbarInteraction();

			VideoPlayerController.SetDefaultVideoPlayerOverlayDelegate();

			overlayView.EnableTopBar();

			_hasVideoPlayerControl = false;

		}

		#region GMFPlayerOverlayViewControllerDelegate
		public void DidPressPlay()
		{
			adsManager.Resume();
		}

		public void DidPressPause()
		{
			adsManager.Pause();
		}

		public void DidPressReplay()
		{
			// nothing to do
		}

		public void DidPressFullscreen(bool isFullscreen)
		{
			VideoPlayerController.DidPressFullscreen(isFullscreen);
		}

		//Cannot seek with ads
		public void DidSeekToTime(double time)
		{
			// nothing to do
		}

		public void DidStartScrubbing()
		{
			// nothing to do
		}

		public void DidEndScrubbing()
		{
			// nothing to do
		}
		#endregion

		public void PlayerControlsWillShow()
		{
			// nothing to do
		}

		public void PlayerControlsDidShow()
		{
			// nothing to do
		}

		public void PlayerControlsWillHide()
		{
			// nothing to do
		}

		public void PlayerControlsDidHide()
		{
			// nothing to do
		}

		#region Debug Methods
		private string AdEventAsString(IMAAdEventType eventType)
		{
			switch (eventType)
			{
				case IMAAdEventType.AllAdsCompleted:
					return "All ads completed";
				case IMAAdEventType.Clicked:
					return "Ad clicked";
				case IMAAdEventType.Complete:
					return "Complete";
				case IMAAdEventType.FirstQuartile:
					return "First quartile reached";
				case IMAAdEventType.Loaded:
					return "Loaded";
				case IMAAdEventType.Midpoint:
					return "Midpoint reached";
				case IMAAdEventType.Pause:
					return "Ad paused";
				case IMAAdEventType.Resume:
					return "Ad resumed";
				case IMAAdEventType.Tapped:
					return "Ad tapped";
				case IMAAdEventType.ThirdQuartile:
					return "Third quartile reached";
				case IMAAdEventType.Started:
					return "Ad started";
				default:
					return "Invalid event type";
			}
		}
		#endregion

		public void Destroy()
		{
			adsLoader.WeakDelegate = null;
			DestroyAdsManager();
		}

		private void DestroyAdsManager()
		{
			if (_willEnterForegroundObserver != null)
			{
				NSNotificationCenter.DefaultCenter.RemoveObserver(_willEnterForegroundObserver);
			}

			if (adsManager != null)
			{
				adsManager.WeakDelegate = null;
			}

			adsManager?.DiscardAdBreak();
			adsManager?.Destroy();
		}


		private class PlayerControlsViewDelegate : GMFPlayerControlsViewDelegate
		{
			private GMFIMAAdService _adService;

			public PlayerControlsViewDelegate(GMFIMAAdService adService)
			{
				_adService = adService;
			}

			[Export("didStartScrubbing")]
			public override void DidStartScrubbing()
			{
				_adService.DidStartScrubbing();
			}

			[Export("didEndScrubbing")]
			public override void DidEndScrubbing()
			{
				_adService.DidEndScrubbing();
			}

			[Export("didPressReplay")]
			public override void DidPressReplay()
			{
				_adService.DidPressPlay();
			}

			[Export("didSeekToTime:")]
			public override void DidSeekToTime(double time)
			{
				_adService.DidSeekToTime(time);
			}

			[Export("didPressFullscreen:")]
			public override void DidPressFullscreen(bool isFullscreen)
			{
				_adService.DidPressFullscreen(isFullscreen);
			}

			[Export("didPressPause")]
			public override void DidPressPause()
			{
				_adService.DidPressPause();
			}

			[Export("didPressPlay")]
			public override void DidPressPlay()
			{
				_adService.DidPressPlay();
			}
		}
	}
}

