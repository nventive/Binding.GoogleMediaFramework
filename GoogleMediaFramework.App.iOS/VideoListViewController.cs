using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using GoogleMediaFramework;
using ObjCRuntime;
using UIKit;
using Constants = GoogleMediaFramework.Constants;

namespace GoogleMediaFramework.App.iOS
{
	public class VideoListViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
	{
		private string _title;
		private List<VideoData> _videos = new List<VideoData>();
		private GMFIMAAdService _adService;
		private GMFPlayerViewController _videoPlayerViewController;
		private bool _isVideoDisplayed;

		private UITableView TableView;
		private NSObject _playbackDidFinishObserver;

		private static float _animationDurantion = 0.2f;
		private static string videoCellId = "videoCell";

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			_title = "Example Videos";

			var screenBounds = UIScreen.MainScreen.Bounds;
			var containerView = new UIView(screenBounds);

			TableView = new UITableView(containerView.Bounds)
			{
				WeakDataSource = this,
				WeakDelegate = this,
				AllowsSelection = true,
			};

			PopulateVideosArray();

			containerView.AddSubview(TableView);

			View = containerView;
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			RemoveVideoPlayerObservers();
		}

		private void ShowPlayer()
		{
			_isVideoDisplayed = true;
			this.AddChildViewController(_videoPlayerViewController);
			_videoPlayerViewController.DidMoveToParentViewController(this);

			this.View.AddSubview(_videoPlayerViewController.View);

			ResizeTableViewAndVideoPlayer();

		}

		private void HidePlayer()
		{
			_isVideoDisplayed = false;
			_videoPlayerViewController.View.RemoveFromSuperview();
			_videoPlayerViewController.RemoveFromParentViewController();

			ResizeTableViewAndVideoPlayer();

		}

		private void ResizeTableViewAndVideoPlayer()
		{
			if (RespondsToSelector(new Selector("setNeedsStatusBarAppearanceUpdate")))
			{
				SetNeedsStatusBarAppearanceUpdate();
			}
			else
			{
				UIApplication.SharedApplication.SetStatusBarHidden(true, UIStatusBarAnimation.Slide);
			}

			var statusBarFrame = UIApplication.SharedApplication.StatusBarFrame.Size;
			var statusBarOffset = Math.Min(statusBarFrame.Height, statusBarFrame.Width);

			var containerWidth = View.Bounds.Size.Width;
			var containerHeight = View.Bounds.Size.Height - statusBarOffset;

			if (_isVideoDisplayed)
			{
				if (InterfaceOrientation == UIInterfaceOrientation.LandscapeLeft ||
					InterfaceOrientation == UIInterfaceOrientation.LandscapeRight)
				{
					UIView.Animate(_animationDurantion, () =>
					{
						TableView.Frame = new CGRect(0, containerHeight, 0, 0);
						_videoPlayerViewController.View.Frame = new CGRect(0, statusBarOffset, containerWidth,
							containerHeight);

					});
				}
				else
				{
					UIView.Animate(_animationDurantion, () =>
					{
						TableView.Frame = new CGRect(0, containerHeight / 2, containerWidth,
						   (containerHeight / 2) + statusBarOffset);
						_videoPlayerViewController.View.Frame = new CGRect(0, statusBarOffset, containerWidth,
							containerHeight / 2);

					});
				}
			}
			else
			{
				UIView.Animate(_animationDurantion, () =>
				{
					TableView.Frame = View.Bounds;
				});
			}
			View.SetNeedsDisplay();

		}

		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			// ResizeTableViewAndVideoPlayer();
		}

		public override bool PrefersStatusBarHidden()
		{
			return ((InterfaceOrientation == UIInterfaceOrientation.LandscapeLeft ||
					 InterfaceOrientation == UIInterfaceOrientation.LandscapeRight) && _isVideoDisplayed);
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return _isVideoDisplayed ? UIStatusBarStyle.LightContent : UIStatusBarStyle.Default;
		}

		private void PopulateVideosArray()
		{
			string contentUrl = "https://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
			if (!_videos.Any())
			{
				_videos.Add(new VideoData(contentUrl, "Video with no ads", string.Empty, null));
				_videos.Add(new VideoData(contentUrl, "Skippable preroll", string.Empty, "http://pubads.g.doubleclick.net/gampad/ads?sz=476x268&cust_params=videostart%3Dtrue&ciu_szs&impl=s&gdfp_req=1&env=vp&output=xml_vast2&unviewed_position_start=1&url=[referrer_url]&correlator=[timestamp]&iu=%2F7226%2Fcplx_app_Trailers_eng"));
				_videos.Add(new VideoData(contentUrl, "Unskippable preroll", string.Empty, "http://pubads.g.doubleclick.net/gampad/ads?sz=476x268&ciu_szs&impl=s&gdfp_req=1&env=vp&output=xml_vast2&unviewed_position_start=1&url=com.fivemobile.cineplex&correlator=030803052087&iu=%2F7226%2Fcplx_app_Trailers_eng&cmsid=172&vid=4706545397001&cust_params=videostart=true"));
				_videos.Add(new VideoData(contentUrl, "Adrules (Preroll and ad breaks at 5s, 10s, 15s)", string.Empty, "http://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=%2F15018773%2Feverything2&ciu_szs=300x250%2C468x60%2C728x90&impl=s&gdfp_req=1&env=vp&output=xml_vmap1&unviewed_position_start=1url=[referrer_url]&correlator=[timestamp]&cmsid=133&vid=10XWSh7W4so&ad_rule=1"));
			}
		}

		#region TableViewDelegate

		public nint RowsInSection(UITableView tableView, nint section)
		{
			return _videos.Count;
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var video = _videos.ElementAt(indexPath.Row);

			//  _videoPlayerViewController?.DidPressMinimize();

			_videoPlayerViewController = new GMFPlayerViewController();

			_playbackDidFinishObserver = NSNotificationCenter.DefaultCenter.AddObserver(Constants.kGMFPlayerStateDidChangeToFinishedNotification,
				PlaybackDidFinish);

			_videoPlayerViewController.LoadStreamWithURL(NSUrl.FromString(video.VideoUrl));

			if (video.AdTagUrl != null)
			{
				_adService = new GMFIMAAdService(_videoPlayerViewController);
				_videoPlayerViewController.RegisterAdService(_adService);

				_adService.RequestAdsWithRequest(video.AdTagUrl);
			}

			ShowPlayer();

			_videoPlayerViewController.ControlTintColor = UIColor.Red;
			_videoPlayerViewController.VideoTitle = video.Title;
			if (video.AdTagUrl == null)
			{
				_videoPlayerViewController.Play();
			}
			//_videoPlayerViewController.ToggleFullscreen();
			tableView.DeselectRow(indexPath, true);
			
		}

		private void PlaybackDidFinish(NSNotification obj)
		{
			RemoveVideoPlayerObservers();
			HidePlayer();
		}

		private void RemoveVideoPlayerObservers()
		{
			if (_playbackDidFinishObserver != null)
			{
				NSNotificationCenter.DefaultCenter.RemoveObserver(_playbackDidFinishObserver);
			}
		}

		#endregion

		public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(videoCellId) ?? new UITableViewCell(UITableViewCellStyle.Subtitle, videoCellId);

			var video = _videos.ElementAt(indexPath.Row);
			cell.TextLabel.Text = video.Title;
			cell.DetailTextLabel.Text = video.Summary;
			cell.UserInteractionEnabled = true;

			return cell;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				RemoveVideoPlayerObservers();
			}
			base.Dispose(disposing);
		}
	}
}