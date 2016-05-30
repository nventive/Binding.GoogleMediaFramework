using System;
using AVFoundation;
using AVKit;
using Foundation;
using ObjCRuntime;
using UIKit;



namespace GoogleMediaFramework
{
	[Static]
	partial interface Constants
	{
		// extern const int kIMAAutodetectBitrate;
		[Field("kIMAAutodetectBitrate", "__Internal")]
		int kIMAAutodetectBitrate { get; }

		// extern NSString *const kGMFPlayerCurrentMediaTimeDidChangeNotification;
		[Field("kGMFPlayerCurrentMediaTimeDidChangeNotification", "__Internal")]
		NSString kGMFPlayerCurrentMediaTimeDidChangeNotification { get; }

		// extern NSString *const kGMFPlayerCurrentTotalTimeDidChangeNotification;
		[Field("kGMFPlayerCurrentTotalTimeDidChangeNotification", "__Internal")]
		NSString kGMFPlayerCurrentTotalTimeDidChangeNotification { get; }

		/*// extern NSString *const kGMFPlayerDidMinimizeNotification;
		[Field("kGMFPlayerDidMinimizeNotification", "__Internal")]
		NSString kGMFPlayerDidMinimizeNotification { get; }*/

		// extern NSString *const kGMFPlayerPlaybackStateDidChangeNotification;
		[Field("kGMFPlayerPlaybackStateDidChangeNotification", "__Internal")]
		NSString kGMFPlayerPlaybackStateDidChangeNotification { get; }

		[Field("kGMFPlayerWillEnterFullscreen", "__Internal")]
		NSString kGMFPlayerWillEnterFullscreen { get; }

		[Field("kGMFPlayerWillExitFullscreen", "__Internal")]
		NSString kGMFPlayerWillExitFullscreen { get; }

		// extern NSString *const kGMFPlayerStateDidChangeToFinishedNotification;
		[Field("kGMFPlayerStateDidChangeToFinishedNotification", "__Internal")]
		NSString kGMFPlayerStateDidChangeToFinishedNotification { get; }

		// extern NSString *const kGMFPlayerStateWillChangeToFinishedNotification;
		[Field("kGMFPlayerStateWillChangeToFinishedNotification", "__Internal")]
		NSString kGMFPlayerStateWillChangeToFinishedNotification { get; }

		// extern NSString *const kGMFPlayerPlaybackDidFinishReasonUserInfoKey;
		[Field("kGMFPlayerPlaybackDidFinishReasonUserInfoKey", "__Internal")]
		NSString kGMFPlayerPlaybackDidFinishReasonUserInfoKey { get; }

		// extern NSString *const kGMFPlayerPlaybackWillFinishReasonUserInfoKey;
		[Field("kGMFPlayerPlaybackWillFinishReasonUserInfoKey", "__Internal")]
		NSString kGMFPlayerPlaybackWillFinishReasonUserInfoKey { get; }
	}

	// @protocol GMFPlayerControlsViewDelegate <NSObject>
	[BaseType(typeof(NSObject))]
	[Model, Protocol]
	interface GMFPlayerControlsViewDelegate
	{
		// @required -(void)didPressPlay;
		[Abstract]
		[Export("didPressPlay")]
		void DidPressPlay();

		// @required -(void)didPressPause;s
		[Abstract]
		[Export("didPressPause")]
		void DidPressPause();

		// @required -(void)didPressReplay;
		[Abstract]
		[Export("didPressReplay")]
		void DidPressReplay();


		// @required -(void)didPressFullscreen:(BOOL)isFullscreen;
		[Abstract]
		[Export("didPressFullscreen:")]
		void DidPressFullscreen(bool isFullscreen);


		// @required -(void)didSeekToTime:(NSTimeInterval)time;
		[Abstract]
		[Export("didSeekToTime:")]
		void DidSeekToTime(double time);

		// @required -(void)didStartScrubbing;
		[Abstract]
		[Export("didStartScrubbing")]
		void DidStartScrubbing();

		// @required -(void)didEndScrubbing;
		[Abstract]
		[Export("didEndScrubbing")]
		void DidEndScrubbing();
	}

	// @interface GMFPlayerControlsView : UIView
	[BaseType(typeof(UIView))]
	interface GMFPlayerControlsView
	{
		// -(void)setTotalTime:(NSTimeInterval)totalTime;
		[Export("setTotalTime:")]
		void SetTotalTime(double totalTime);

		// -(void)setDownloadedTime:(NSTimeInterval)downloadedTime;
		[Export("setDownloadedTime:")]
		void SetDownloadedTime(double downloadedTime);

		// -(void)setMediaTime:(NSTimeInterval)mediaTime;
		[Export("setMediaTime:")]
		void SetMediaTime(double mediaTime);

		// -(void)updateScrubberAndTime;
		[Export("updateScrubberAndTime")]
		void UpdateScrubberAndTime();

		// -(CGFloat)preferredHeight;
		[Export("preferredHeight")]
		nfloat PreferredHeight { get; }

		// -(void)setDelegate:(id<GMFPlayerControlsViewDelegate>)delegate;
		[Export("setDelegate:")]
		void SetDelegate(GMFPlayerControlsViewDelegate @delegate);

		// -(void)setSeekbarTrackColor:(UIColor *)color;
		[Export("setSeekbarTrackColor:")]
		void SetSeekbarTrackColor(UIColor color);

		// -(void)disableSeekbarInteraction;
		[Export("disableSeekbarInteraction")]
		void DisableSeekbarInteraction();

		// -(void)enableSeekbarInteraction;
		[Export("enableSeekbarInteraction")]
		void EnableSeekbarInteraction();

		// -(void)applyControlTintColor:(UIColor *)color;
		[Export("applyControlTintColor:")]
		void ApplyControlTintColor(UIColor color);
	}

	// @protocol GMFPlayerControlsProtocol <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface GMFPlayerControlsProtocol
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		GMFPlayerControlsViewDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<GMFPlayerControlsViewDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required -(void)showPlayButton;
		[Abstract]
		[Export("showPlayButton")]
		void ShowPlayButton();

		// @required -(void)showPauseButton;
		[Abstract]
		[Export("showPauseButton")]
		void ShowPauseButton();

		// @required -(void)showReplayButton;
		[Abstract]
		[Export("showReplayButton")]
		void ShowReplayButton();

		// @required -(void)enableSeekbarInteraction;
		[Abstract]
		[Export("enableSeekbarInteraction")]
		void EnableSeekbarInteraction();

		// @required -(void)disableSeekbarInteraction;
		[Abstract]
		[Export("disableSeekbarInteraction")]
		void DisableSeekbarInteraction();

		// @required -(void)setSeekbarTrackColor:(UIColor *)color;
		[Abstract]
		[Export("setSeekbarTrackColor:")]
		void SetSeekbarTrackColor(UIColor color);

		// @required -(void)setTotalTime:(NSTimeInterval)totalTime;
		[Abstract]
		[Export("setTotalTime:")]
		void SetTotalTime(double totalTime);

		// @required -(void)setMediaTime:(NSTimeInterval)mediaTime;
		[Abstract]
		[Export("setMediaTime:")]
		void SetMediaTime(double mediaTime);

		// @optional -(void)addActionButtonWithImage:(UIImage *)image name:(NSString *)name target:(id)target selector:(SEL)selector;
		[Export("addActionButtonWithImage:name:target:selector:")]
		void AddActionButtonWithImage(UIImage image, string name, NSObject target, Selector selector);

		// @optional -(void)applyControlTintColor:(UIColor *)color;
		[Export("applyControlTintColor:")]
		void ApplyControlTintColor(UIColor color);

		// @optional -(void)setVideoTitle:(NSString *)videoTitle;
		[Export("setVideoTitle:")]
		void SetVideoTitle(string videoTitle);

		// @optional -(void)setLogoImage:(UIImage *)logoImage;
		[Export("setLogoImage:")]
		void SetLogoImage(UIImage logoImage);
	}

	// @interface GMFTopBarView : UIView
	[BaseType(typeof(UIView))]
	interface GMFTopBarView
	{
		// -(void)setLogoImage:(UIImage *)logoImage;
		[Export("setLogoImage:")]
		void SetLogoImage(UIImage logoImage);

		// -(void)setVideoTitle:(NSString *)videoTitle;
		[Export("setVideoTitle:")]
		void SetVideoTitle(string videoTitle);

		// -(void)addActionButtonWithImage:(UIImage *)image name:(NSString *)name target:(id)target selector:(SEL)selector;
		[Export("addActionButtonWithImage:name:target:selector:")]
		void AddActionButtonWithImage(UIImage image, string name, NSObject target, Selector selector);

		// -(CGFloat)preferredHeight;
		[Export("preferredHeight")]
		nfloat PreferredHeight { get; }
	}

	// @interface GMFPlayerOverlayView : UIView <GMFPlayerControlsProtocol>
	[BaseType(typeof(UIView))]
	interface GMFPlayerOverlayView : GMFPlayerControlsProtocol
	{
		// @property (readonly, nonatomic) GMFPlayerControlsView * playerControlsView;
		[Export("playerControlsView")]
		GMFPlayerControlsView PlayerControlsView { get; }

		// @property (readonly, nonatomic) GMFTopBarView * topBarView;
		[Export("topBarView", ArgumentSemantic.Weak)]
		GMFTopBarView TopBarView { get; }

		// @property (nonatomic, strong) UIColor * playPauseResetButtonBackgroundColor;
		[Export("playPauseResetButtonBackgroundColor", ArgumentSemantic.Strong)]
		UIColor PlayPauseResetButtonBackgroundColor { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		GMFPlayerControlsViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GMFPlayerControlsViewDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)showSpinner;
		[Export("showSpinner")]
		void ShowSpinner();

		// -(void)hideSpinner;
		[Export("hideSpinner")]
		void HideSpinner();

		// -(void)setPlayerBarVisible:(BOOL)visible;
		[Export("setPlayerBarVisible:")]
		void SetPlayerBarVisible(bool visible);

		// -(void)setSeekbarTrackColor:(UIColor *)color;
		[Export("setSeekbarTrackColor:")]
		void SetSeekbarTrackColor(UIColor color);

		// -(void)setSeekbarTrackColorDefault;
		[Export("setSeekbarTrackColorDefault")]
		void SetSeekbarTrackColorDefault();

		// -(void)addActionButtonWithImage:(UIImage *)image name:(NSString *)name target:(id)target selector:(SEL)selector;
		[Export("addActionButtonWithImage:name:target:selector:")]
		void AddActionButtonWithImage(UIImage image, string name, NSObject target, Selector selector);

		// -(void)applyControlTintColor:(UIColor *)color;
		[Export("applyControlTintColor:")]
		void ApplyControlTintColor(UIColor color);

		// -(void)setVideoTitle:(NSString *)videoTitle;
		[Export("setVideoTitle:")]
		void SetVideoTitle(string videoTitle);

		// -(void)setLogoImage:(UIImage *)logoImage;
		[Export("setLogoImage:")]
		void SetLogoImage(UIImage logoImage);

		// -(void)disableTopBar;
		[Export("disableTopBar")]
		void DisableTopBar();

		// -(void)enableTopBar;
		[Export("enableTopBar")]
		void EnableTopBar();
	}

	// @interface GMFPlayerView : UIView
	[BaseType(typeof(UIView))]
	interface GMFPlayerView
	{
		// @property (nonatomic, weak) UIView * _Nullable aboveRenderingView;
		[NullAllowed, Export("aboveRenderingView", ArgumentSemantic.Weak)]
		UIView AboveRenderingView { get; set; }

		// @property (nonatomic, strong) UIView * renderingView;
		[Export("renderingView", ArgumentSemantic.Strong)]
		UIView RenderingView { get; set; }

		// @property (readonly, nonatomic) UIView * gestureCapturingView;
		[Export("gestureCapturingView")]
		UIView GestureCapturingView { get; }

		// -(void)reset;
		[Export("reset")]
		void Reset();

		// -(void)setVideoRenderingView:(UIView *)renderingView;
		[Export("setVideoRenderingView:")]
		void SetVideoRenderingView(UIView renderingView);

		// -(void)setOverlayView:(UIView<GMFPlayerControlsProtocol> *)overlayView;
		[Export("setOverlayView:")]
		void SetOverlayView(GMFPlayerControlsProtocol overlayView);
	}

	// @protocol GMFVideoPlayerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface GMFVideoPlayerDelegate
	{
		// @required -(void)videoPlayer:(GMFVideoPlayer *)videoPlayer stateDidChangeFrom:(GMFPlayerState)fromState to:(GMFPlayerState)toState;
		[Abstract]
		[Export("videoPlayer:stateDidChangeFrom:to:")]
		void StateDidChangeFrom(GMFVideoPlayer videoPlayer, GMFPlayerState fromState, GMFPlayerState toState);

		// @required -(void)videoPlayer:(GMFVideoPlayer *)videoPlayer currentMediaTimeDidChangeToTime:(NSTimeInterval)time;
		[Abstract]
		[Export("videoPlayer:currentMediaTimeDidChangeToTime:")]
		void CurrentMediaTimeDidChangeToTime(GMFVideoPlayer videoPlayer, double time);

		// @required -(void)videoPlayer:(GMFVideoPlayer *)videoPlayer currentTotalTimeDidChangeToTime:(NSTimeInterval)time;
		[Abstract]
		[Export("videoPlayer:currentTotalTimeDidChangeToTime:")]
		void CurrentTotalTimeDidChangeToTime(GMFVideoPlayer videoPlayer, double time);

		// @optional -(void)videoPlayer:(GMFVideoPlayer *)videoPlayer bufferedMediaTimeDidChangeToTime:(NSTimeInterval)time;
		[Export("videoPlayer:bufferedMediaTimeDidChangeToTime:")]
		void BufferedMediaTimeDidChangeToTime(GMFVideoPlayer videoPlayer, double time);
	}

	// @interface GMFVideoPlayer : NSObject
	[BaseType(typeof(NSObject))]
	interface GMFVideoPlayer
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		GMFVideoPlayerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GMFVideoPlayerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) GMFPlayerState state;
		[Export("state")]
		GMFPlayerState State { get; }

		// @property (readonly, nonatomic) UIView * renderingView;
		[Export("renderingView")]
		UIView RenderingView { get; }

		// -(void)loadStreamWithURL:(NSURL *)url;
		[Export("loadStreamWithURL:")]
		void LoadStreamWithURL(NSUrl url);

		// -(void)reset;
		[Export("reset")]
		void Reset();

		// -(void)play;
		[Export("play")]
		void Play();

		// -(void)pause;
		[Export("pause")]
		void Pause();

		// -(void)replay;
		[Export("replay")]
		void Replay();

		// -(void)seekToTime:(NSTimeInterval)time;
		[Export("seekToTime:")]
		void SeekToTime(double time);

		// -(NSTimeInterval)currentMediaTime;
		[Export("currentMediaTime")]
		double CurrentMediaTime { get; }

		// -(NSTimeInterval)totalMediaTime;
		[Export("totalMediaTime")]
		double TotalMediaTime { get; }

		// -(NSTimeInterval)bufferedMediaTime;
		[Export("bufferedMediaTime")]
		double BufferedMediaTime { get; }
	}

	// @protocol GMFPlayerOverlayViewControllerDelegate <GMFPlayerControlsViewDelegate>
	[BaseType(typeof(NSObject))]
	[Protocol, Model]
	interface GMFPlayerOverlayViewControllerDelegate : GMFPlayerControlsViewDelegate
	{
		// @optional -(void)playerControlsWillShow;
		[Export("playerControlsWillShow")]
		void PlayerControlsWillShow();

		// @optional -(void)playerControlsDidShow;
		[Export("playerControlsDidShow")]
		void PlayerControlsDidShow();

		// @optional -(void)playerControlsWillHide;
		[Export("playerControlsWillHide")]
		void PlayerControlsWillHide();

		// @optional -(void)playerControlsDidHide;
		[Export("playerControlsDidHide")]
		void PlayerControlsDidHide();
	}

	// @protocol GMFPlayerOverlayViewControllerProtocol <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]

	interface GMFPlayerOverlayViewControllerProtocol
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		GMFPlayerOverlayViewControllerDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<GMFPlayerOverlayViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required @property (nonatomic, strong) UIView<GMFPlayerControlsProtocol> * playerOverlayView;
		[Export("playerOverlayView", ArgumentSemantic.Strong)]
		GMFPlayerControlsProtocol PlayerOverlayView { get; set; }

		// @required @property (nonatomic) BOOL userScrubbing;
		[Export("userScrubbing")]
		bool UserScrubbing { get; set; }

		// @required -(void)showPlayerControlsAnimated:(BOOL)animated;
		[Abstract]
		[Export("showPlayerControlsAnimated:")]
		void ShowPlayerControlsAnimated(bool animated);

		// @required -(void)hidePlayerControlsAnimated:(BOOL)animated;
		[Abstract]
		[Export("hidePlayerControlsAnimated:")]
		void HidePlayerControlsAnimated(bool animated);

		// @required -(void)setTotalTime:(NSTimeInterval)totalTime;
		[Abstract]
		[Export("setTotalTime:")]
		void SetTotalTime(double totalTime);

		// @required -(void)setMediaTime:(NSTimeInterval)mediaTime;
		[Abstract]
		[Export("setMediaTime:")]
		void SetMediaTime(double mediaTime);

		// @required -(void)togglePlayerControlsVisibility;
		[Abstract]
		[Export("togglePlayerControlsVisibility")]
		void TogglePlayerControlsVisibility();

		// @required -(void)playerStateDidChangeToState:(GMFPlayerState)toState;
		[Abstract]
		[Export("playerStateDidChangeToState:")]
		void PlayerStateDidChangeToState(GMFPlayerState toState);

		// @required -(void)reset;
		[Abstract]
		[Export("reset")]
		void Reset();
	}

	// @interface GMFPlayerOverlayViewController : UIViewController <GMFPlayerOverlayViewControllerProtocol>
	[BaseType(typeof(UIViewController))]
	interface GMFPlayerOverlayViewController : GMFPlayerOverlayViewControllerProtocol
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		GMFPlayerOverlayViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GMFPlayerOverlayViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) UIView<GMFPlayerControlsProtocol> * playerOverlayView;
		[Export("playerOverlayView", ArgumentSemantic.Strong)]
		GMFPlayerControlsProtocol PlayerOverlayView { get; set; }

		// @property (nonatomic) BOOL userScrubbing;
		[Export("userScrubbing")]
		bool UserScrubbing { get; set; }

		[Wrap("WeakVideoPlayerOverlayViewControllerDelegate")]
		[NullAllowed]
		GMFPlayerOverlayViewControllerDelegate VideoPlayerOverlayViewControllerDelegate { get; set; }

		// @property (nonatomic, weak) id<GMFPlayerOverlayViewControllerDelegate> _Nullable videoPlayerOverlayViewControllerDelegate;
		[NullAllowed, Export("videoPlayerOverlayViewControllerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakVideoPlayerOverlayViewControllerDelegate { get; set; }

		// @property (nonatomic) BOOL isAdDisplayed;
		[Export("isAdDisplayed")]
		bool IsAdDisplayed { get; set; }

		// -(void)playerStateDidChangeToState:(GMFPlayerState)toState;
		[Export("playerStateDidChangeToState:")]
		void PlayerStateDidChangeToState(GMFPlayerState toState);

		// -(void)playerControlsDidHide;
		[Export("playerControlsDidHide")]
		void PlayerControlsDidHide();

		// -(void)playerControlsWillHide;
		[Export("playerControlsWillHide")]
		void PlayerControlsWillHide();

		// -(void)playerControlsDidShow;
		[Export("playerControlsDidShow")]
		void PlayerControlsDidShow();

		// -(void)playerControlsWillShow;
		[Export("playerControlsWillShow")]
		void PlayerControlsWillShow();

		// -(GMFPlayerControlsView *)playerControlsView;
		[Export("playerControlsView")]
		GMFPlayerControlsView PlayerControlsView { get; }

		// -(void)resetAutoHideTimer;
		[Export("resetAutoHideTimer")]
		void ResetAutoHideTimer();
	}



	// @interface GMFPlayerViewController : UIViewController <GMFVideoPlayerDelegate, GMFPlayerOverlayViewControllerDelegate, GMFPlayerControlsViewDelegate, UIGestureRecognizerDelegate>
	[BaseType(typeof(UIViewController))]
	interface GMFPlayerViewController : GMFVideoPlayerDelegate, GMFPlayerOverlayViewControllerDelegate, GMFPlayerControlsViewDelegate, IUIGestureRecognizerDelegate
	{
		// @property (readonly, nonatomic) GMFPlayerView * playerView;
		[Export("playerView")]
		GMFPlayerView PlayerView { get; }

		// @property (nonatomic, strong) UIViewController<GMFPlayerOverlayViewControllerProtocol> * videoPlayerOverlayViewController;
		[Export("videoPlayerOverlayViewController", ArgumentSemantic.Strong)]
		GMFPlayerOverlayViewController VideoPlayerOverlayViewController { get; set; }

		// @property (nonatomic, weak) GMFAdService * _Nullable adService;
		[NullAllowed, Export("adService", ArgumentSemantic.Weak)]
		GMFAdService AdService { get; set; }

		// @property (readonly, getter = isVideoFinished, nonatomic) BOOL videoFinished;
		[Export("videoFinished")]
		bool VideoFinished { [Bind("isVideoFinished")] get; }

		// @property (nonatomic, strong) UIColor * controlTintColor;
		[Export("controlTintColor", ArgumentSemantic.Strong)]
		UIColor ControlTintColor { get; set; }

		// @property (nonatomic, strong) NSString * videoTitle;
		[Export("videoTitle", ArgumentSemantic.Strong)]
		string VideoTitle { get; set; }

		// @property (nonatomic, strong) UIImage * logoImage;
		[Export("logoImage", ArgumentSemantic.Strong)]
		UIImage LogoImage { get; set; }

		// @property (nonatomic) BOOL isFullscreen;
		[Export("isFullscreen")]
		bool IsFullscreen { get; set; }

		// @property (nonatomic) BOOL shouldHideControls;
		[Export("shouldHideControls")]
		bool ShouldHideControls { get; set; }

		// -(void)loadStreamWithURL:(NSURL *)URL;
		[Export("loadStreamWithURL:")]
		void LoadStreamWithURL(NSUrl URL);

		// -(void)play;
		[Export("play")]
		void Play();

		// -(void)pause;
		[Export("pause")]
		void Pause();

		// -(void)stop;
		[Export("stop")]
		void Stop();

		// -(void)setFullscreen:(BOOL)isFullscreen;
		[Export("setFullscreen:")]
		void SetFullscreen(bool isFullscreen);

		// -(GMFPlayerState)playbackState;
		[Export("playbackState")]
		GMFPlayerState PlaybackState { get; }

		// -(NSTimeInterval)currentMediaTime;
		[Export("currentMediaTime")]
		double CurrentMediaTime { get; }

		// -(NSTimeInterval)totalMediaTime;
		[Export("totalMediaTime")]
		double TotalMediaTime { get; }

		// -(void)addActionButtonWithImage:(UIImage *)image name:(NSString *)name target:(id)target selector:(SEL)selector;
		[Export("addActionButtonWithImage:name:target:selector:")]
		void AddActionButtonWithImage(UIImage image, string name, NSObject target, Selector selector);

		// -(void)registerAdService:(GMFAdService *)adService;
		[Export("registerAdService:")]
		void RegisterAdService(GMFAdService adService);

		// -(void)setAboveRenderingView:(UIView *)view;
		[Export("setAboveRenderingView:")]
		void SetAboveRenderingView(UIView view);

		// -(void)setControlsVisibility:(BOOL)visible animated:(BOOL)animated;
		[Export("setControlsVisibility:animated:")]
		void SetControlsVisibility(bool visible, bool animated);

		// -(void)setVideoPlayerOverlayDelegate:(id<GMFPlayerControlsViewDelegate>)delegate;
		[Export("setVideoPlayerOverlayDelegate:")]
		void SetVideoPlayerOverlayDelegate(GMFPlayerControlsViewDelegate @delegate);

		// -(void)setDefaultVideoPlayerOverlayDelegate;
		[Export("setDefaultVideoPlayerOverlayDelegate")]
		void SetDefaultVideoPlayerOverlayDelegate();

		// -(UIView<GMFPlayerControlsProtocol> *)playerOverlayView;
		[Export("playerOverlayView")]
		GMFPlayerOverlayView PlayerOverlayView { get; }
	}

	// @interface GMFAdService : NSObject
	[BaseType(typeof(NSObject))]
	interface GMFAdService
	{
		// @property (nonatomic, weak) GMFPlayerViewController * _Nullable videoPlayerController;
		[NullAllowed, Export("videoPlayerController", ArgumentSemantic.Weak)]
		GMFPlayerViewController VideoPlayerController { get; set; }

		// -(id)initWithGMFVideoPlayer:(GMFPlayerViewController *)videoPlayerController;
		[Export("initWithGMFVideoPlayer:")]
		IntPtr Constructor(GMFPlayerViewController videoPlayerController);
	}

	// @interface GMFResources : NSObject
	[BaseType(typeof(NSObject))]
	interface GMFResources
	{
		// +(UIImage *)playerBarPlayButtonImage;
		[Static]
		[Export("playerBarPlayButtonImage")]
		UIImage PlayerBarPlayButtonImage { get; }

		// +(UIImage *)playerBarPlayLargeButtonImage;
		[Static]
		[Export("playerBarPlayLargeButtonImage")]
		UIImage PlayerBarPlayLargeButtonImage { get; }

		// +(UIImage *)playerBarPauseButtonImage;
		[Static]
		[Export("playerBarPauseButtonImage")]
		UIImage PlayerBarPauseButtonImage { get; }

		// +(UIImage *)playerBarPauseLargeButtonImage;
		[Static]
		[Export("playerBarPauseLargeButtonImage")]
		UIImage PlayerBarPauseLargeButtonImage { get; }

		// +(UIImage *)playerBarReplayButtonImage;
		[Static]
		[Export("playerBarReplayButtonImage")]
		UIImage PlayerBarReplayButtonImage { get; }

		// +(UIImage *)playerBarReplayLargeButtonImage;
		[Static]
		[Export("playerBarReplayLargeButtonImage")]
		UIImage PlayerBarReplayLargeButtonImage { get; }

		// +(UIImage *)playerBarMinimizeButtonImage;
		[Static]
		[Export("playerBarMinimizeButtonImage")]
		UIImage PlayerBarMinimizeButtonImage { get; }

		// +(UIImage *)playerBarMaximizeButtonImage;
		[Static]
		[Export("playerBarMaximizeButtonImage")]
		UIImage PlayerBarMaximizeButtonImage { get; }

		// +(UIImage *)playerBarScrubberThumbImage;
		[Static]
		[Export("playerBarScrubberThumbImage")]
		UIImage PlayerBarScrubberThumbImage { get; }

		// +(UIImage *)playerBarBackgroundImage;
		[Static]
		[Export("playerBarBackgroundImage")]
		UIImage PlayerBarBackgroundImage { get; }

		// +(UIImage *)playerTitleBarBackgroundImage;
		[Static]
		[Export("playerTitleBarBackgroundImage")]
		UIImage PlayerTitleBarBackgroundImage { get; }
	}

	// @interface GMFTintableButton (UIButton)
	[Category]
	[BaseType(typeof(UIButton))]
	interface UIButton_GMFTintableButton
	{
		// -(void)GMF_applyTintColor:(UIColor *)color;
		[Export("GMF_applyTintColor:")]
		void GMF_applyTintColor(UIColor color);
	}

	// @interface GMFTintableImage (UIImage)
	[Category]
	[BaseType(typeof(UIImage))]
	interface UIImage_GMFTintableImage
	{
		// -(UIImage *)GMF_createTintedImage:(UIColor *)color;
		[Export("GMF_createTintedImage:")]
		UIImage GMF_createTintedImage(UIColor color);
	}

	// @interface GMFLabelsAdditions (UILabel)
	[Category]
	[BaseType(typeof(UILabel))]
	interface UILabel_GMFLabelsAdditions
	{
		// +(UILabel *)GMF_clearLabelForPlayerControls;
		[Static]
		[Export("GMF_clearLabelForPlayerControls")]
		UILabel GMF_clearLabelForPlayerControls { get; }
	}

	// @interface GMFSlider (UISlider)
	[Category]
	[BaseType(typeof(UISlider))]
	interface UISlider_GMFSlider
	{
	}

	// @protocol IMAContentPlayhead
	[BaseType(typeof(NSObject))]
	[Protocol, Model]
	interface IMAContentPlayhead
	{
		// @required @property (readonly, nonatomic) NSTimeInterval currentTime;
		[Export("currentTime")]
		double CurrentTime { get; }
	}

	// @interface IMAAVPlayerContentPlayhead : NSObject <IMAContentPlayhead>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAVPlayerContentPlayhead : IMAContentPlayhead
	{
		// @property (readonly, nonatomic, strong) AVPlayer * player;
		[Export("player", ArgumentSemantic.Strong)]
		AVPlayer Player { get; }

		// -(instancetype)initWithAVPlayer:(AVPlayer *)player;
		[Export("initWithAVPlayer:")]
		IntPtr Constructor(AVPlayer player);
	}

	// @protocol IMAAdPlaybackInfo <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAAdPlaybackInfo
	{
		// @required @property (readonly, nonatomic) NSTimeInterval currentMediaTime;
		[Export("currentMediaTime")]
		double CurrentMediaTime { get; }

		// @required @property (readonly, nonatomic) NSTimeInterval totalMediaTime;
		[Export("totalMediaTime")]
		double TotalMediaTime { get; }

		// @required @property (readonly, nonatomic) NSTimeInterval bufferedMediaTime;
		[Export("bufferedMediaTime")]
		double BufferedMediaTime { get; }

		// @required @property (readonly, getter = isPlaying, nonatomic) BOOL playing;
		[Export("playing")]
		bool Playing { [Bind("isPlaying")] get; }
	}

	// @protocol IMAVideoDisplayDelegate <NSObject>
	[BaseType(typeof(NSObject))]
	[Model]
	interface IMAVideoDisplayDelegate
	{
		// @required -(void)onPlay;
		[Abstract]
		[Export("onPlay")]
		void OnPlay();

		// @required -(void)onVolumeChangedToVolume:(float)volume;
		[Abstract]
		[Export("onVolumeChangedToVolume:")]
		void OnVolumeChangedToVolume(float volume);

		// @required -(void)onProgressWithMediaTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)totalTime;
		[Abstract]
		[Export("onProgressWithMediaTime:totalTime:")]
		void OnProgressWithMediaTime(double mediaTime, double totalTime);

		// @required -(void)onClick;
		[Abstract]
		[Export("onClick")]
		void OnClick();

		// @required -(void)onPause;
		[Abstract]
		[Export("onPause")]
		void OnPause();

		// @required -(void)onResume;
		[Abstract]
		[Export("onResume")]
		void OnResume();

		// @required -(void)onComplete;
		[Abstract]
		[Export("onComplete")]
		void OnComplete();

		// @required -(void)onError;
		[Abstract]
		[Export("onError")]
		void OnError();

		// @required -(void)onSkip;
		[Abstract]
		[Export("onSkip")]
		void OnSkip();

		// @required -(void)onSkipShown;
		[Abstract]
		[Export("onSkipShown")]
		void OnSkipShown();

		// @required -(void)onStart;
		[Abstract]
		[Export("onStart")]
		void OnStart();

		// @required -(void)onTimedMetadata:(NSDictionary *)metadata;
		[Abstract]
		[Export("onTimedMetadata:")]
		void OnTimedMetadata(NSDictionary metadata);

		// @required -(void)onLoaded;
		[Abstract]
		[Export("onLoaded")]
		void OnLoaded();

		// @optional -(void)onBufferedWithMediaTime:(NSTimeInterval)mediaTime;
		[Export("onBufferedWithMediaTime:")]
		void OnBufferedWithMediaTime(double mediaTime);

		// @optional -(void)onPlaybackReady;
		[Export("onPlaybackReady")]
		void OnPlaybackReady();

		// @optional -(void)onStartBuffering;
		[Export("onStartBuffering")]
		void OnStartBuffering();
	}

	// @protocol IMAVideoDisplay <IMAAdPlaybackInfo>
	[BaseType(typeof(NSObject))]
	[Protocol, Model]
	[DisableDefaultCtor]
	interface IIMAVideoDisplay : IMAAdPlaybackInfo
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		IMAVideoDisplayDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<IMAVideoDisplayDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required -(void)loadUrl:(NSURL *)url;
		[Abstract]
		[Export("loadUrl:")]
		void LoadUrl(NSUrl url);

		// @required -(void)play;
		[Abstract]
		[Export("play")]
		void Play();

		// @required -(void)pause;
		[Abstract]
		[Export("pause")]
		void Pause();

		// @required -(void)reset;
		[Abstract]
		[Export("reset")]
		void Reset();
	}

	// @interface IMAAVPlayerVideoDisplay : NSObject <IMAVideoDisplay>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAVPlayerVideoDisplay : IIMAVideoDisplay
	{
		// @property (readonly, nonatomic, strong) AVPlayer * player;
		[Export("player", ArgumentSemantic.Strong)]
		AVPlayer Player { get; }

		// -(instancetype)initWithAVPlayer:(AVPlayer *)player;
		[Export("initWithAVPlayer:")]
		IntPtr Constructor(AVPlayer player);
	}

	// @interface IMAAdPodInfo : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdPodInfo
	{
		// @property (readonly, nonatomic) int totalAds;
		[Export("totalAds")]
		int TotalAds { get; }

		// @property (readonly, nonatomic) int adPosition;
		[Export("adPosition")]
		int AdPosition { get; }

		// @property (readonly, nonatomic) BOOL isBumper;
		[Export("isBumper")]
		bool IsBumper { get; }

		// @property (readonly, nonatomic) int podIndex;
		[Export("podIndex")]
		int PodIndex { get; }

		// @property (readonly, nonatomic) NSTimeInterval timeOffset;
		[Export("timeOffset")]
		double TimeOffset { get; }

		// @property (readonly, nonatomic) NSTimeInterval maxDuration;
		[Export("maxDuration")]
		double MaxDuration { get; }
	}

	// @interface IMAAd : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAd
	{
		// @property (readonly, copy, nonatomic) NSString * adId;
		[Export("adId")]
		string AdId { get; }

		// @property (readonly, copy, nonatomic) NSString * adTitle;
		[Export("adTitle")]
		string AdTitle { get; }

		// @property (readonly, copy, nonatomic) NSString * adDescription;
		[Export("adDescription")]
		string AdDescription { get; }

		// @property (readonly, copy, nonatomic) NSString * contentType;
		[Export("contentType")]
		string ContentType { get; }

		// @property (readonly, nonatomic) NSTimeInterval duration;
		[Export("duration")]
		double Duration { get; }

		// @property (readonly, copy, nonatomic) NSArray * uiElements;
		[Export("uiElements", ArgumentSemantic.Copy)]
		NSObject[] UiElements { get; }

		// @property (readonly, nonatomic) int width;
		[Export("width")]
		int Width { get; }

		// @property (readonly, nonatomic) int height;
		[Export("height")]
		int Height { get; }

		// @property (readonly, getter = isLinear, nonatomic) BOOL linear;
		[Export("linear")]
		bool Linear { [Bind("isLinear")] get; }

		// @property (readonly, getter = isSkippable, nonatomic) BOOL skippable;
		[Export("skippable")]
		bool Skippable { [Bind("isSkippable")] get; }

		// @property (readonly, nonatomic, strong) IMAAdPodInfo * adPodInfo;
		[Export("adPodInfo", ArgumentSemantic.Strong)]
		IMAAdPodInfo AdPodInfo { get; }

		// @property (readonly, copy, nonatomic) NSString * traffickingParameters;
		[Export("traffickingParameters")]
		string TraffickingParameters { get; }
	}

	// @interface IMAAdDisplayContainer : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdDisplayContainer
	{
		// @property (readonly, nonatomic, strong) UIView * adContainer;
		[Export("adContainer", ArgumentSemantic.Strong)]
		UIView AdContainer { get; }

		// @property (readonly, copy, nonatomic) NSArray * companionSlots;
		[Export("companionSlots", ArgumentSemantic.Copy)]
		NSObject[] CompanionSlots { get; }

		// -(instancetype)initWithAdContainer:(UIView *)adContainer companionSlots:(NSArray *)companionSlots __attribute__((objc_designated_initializer));
		[Export("initWithAdContainer:companionSlots:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIView adContainer, [NullAllowed] NSObject[] companionSlots);
	}

	// @interface IMAAdError : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdError
	{
		// @property (readonly, nonatomic) IMAErrorType type;
		[Export("type")]
		IMAErrorType Type { get; }

		// @property (readonly, nonatomic) IMAErrorCode code;
		[Export("code")]
		IMAErrorCode Code { get; }

		// @property (readonly, copy, nonatomic) NSString * message;
		[Export("message")]
		string Message { get; }
	}

	// @interface IMAAdEvent : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdEvent
	{
		// @property (readonly, nonatomic) IMAAdEventType type;
		[Export("type")]
		IMAAdEventType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * typeString;
		[Export("typeString")]
		string TypeString { get; }

		// @property (readonly, nonatomic, strong) IMAAd * ad;
		[Export("ad", ArgumentSemantic.Strong)]
		IMAAd Ad { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * adData;
		[Export("adData", ArgumentSemantic.Copy)]
		NSDictionary AdData { get; }
	}

	// @interface IMAAdsLoadedData : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAAdsLoadedData
	{
		// @property (readonly, nonatomic, strong) IMAAdsManager * adsManager;
		[Export("adsManager", ArgumentSemantic.Strong)]
		IMAAdsManager AdsManager { get; }

		// @property (readonly, nonatomic, strong) IMAStreamManager * streamManager;
		[Export("streamManager", ArgumentSemantic.Strong)]
		IMAStreamManager StreamManager { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }
	}

	// @interface IMAAdLoadingErrorData : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAAdLoadingErrorData
	{
		// @property (readonly, nonatomic, strong) IMAAdError * adError;
		[Export("adError", ArgumentSemantic.Strong)]
		IMAAdError AdError { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }
	}

	// @protocol IMAAdsLoaderDelegate
	[BaseType(typeof(NSObject))]
	[Protocol, Model]
	interface IMAAdsLoaderDelegate
	{
		// @required -(void)adsLoader:(IMAAdsLoader *)loader adsLoadedWithData:(IMAAdsLoadedData *)adsLoadedData;
		[Abstract]
		[Export("adsLoader:adsLoadedWithData:")]
		void AdsLoadedWithData(IMAAdsLoader loader, IMAAdsLoadedData adsLoadedData);

		// @required -(void)adsLoader:(IMAAdsLoader *)loader failedWithErrorData:(IMAAdLoadingErrorData *)adErrorData;
		[Abstract]
		[Export("adsLoader:failedWithErrorData:")]
		void FailedWithErrorData(IMAAdsLoader loader, IMAAdLoadingErrorData adErrorData);
	}

	// @interface IMAAdsLoader : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAAdsLoader
	{
		// @property (readonly, copy, nonatomic) IMASettings * settings;
		[Export("settings", ArgumentSemantic.Copy)]
		IMASettings Settings { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		IMAAdsLoaderDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<IMAAdsLoaderDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(NSString *)sdkVersion;
		[Static]
		[Export("sdkVersion")]
		string SdkVersion { get; }

		// -(instancetype)initWithSettings:(IMASettings *)settings;
		[Export("initWithSettings:")]
		IntPtr Constructor(IMASettings settings);

		// -(void)requestAdsWithRequest:(IMAAdsRequest *)request;
		[Export("requestAdsWithRequest:")]
		void RequestAdsWithRequest(IMAAdsRequest request);

		// -(void)requestStreamWithRequest:(IMAStreamRequest *)request;
		[Export("requestStreamWithRequest:")]
		void RequestStreamWithRequest(IMAStreamRequest request);

		// -(void)contentComplete;
		[Export("contentComplete")]
		void ContentComplete();
	}

	// @protocol IMAAdsManagerDelegate
	[Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface IMAAdsManagerDelegate
	{
		// @required -(void)adsManager:(IMAAdsManager *)adsManager didReceiveAdEvent:(IMAAdEvent *)event;
		[Abstract]
		[Export("adsManager:didReceiveAdEvent:")]
		void AdsManager(IMAAdsManager adsManager, IMAAdEvent adEvent);

		// @required -(void)adsManager:(IMAAdsManager *)adsManager didReceiveAdError:(IMAAdError *)error;
		[Abstract]
		[Export("adsManager:didReceiveAdError:")]
		void AdsManager(IMAAdsManager adsManager, IMAAdError error);

		// @required -(void)adsManagerDidRequestContentPause:(IMAAdsManager *)adsManager;
		[Abstract]
		[Export("adsManagerDidRequestContentPause:")]
		void AdsManagerDidRequestContentPause(IMAAdsManager adsManager);

		// @required -(void)adsManagerDidRequestContentResume:(IMAAdsManager *)adsManager;
		[Abstract]
		[Export("adsManagerDidRequestContentResume:")]
		void AdsManagerDidRequestContentResume(IMAAdsManager adsManager);

		// @optional -(void)adsManager:(IMAAdsManager *)adsManager adDidProgressToTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)totalTime;
		[Export("adsManager:adDidProgressToTime:totalTime:")]
		void AdsManager(IMAAdsManager adsManager, double mediaTime, double totalTime);

		// @optional -(void)adDidProgressToTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)totalTime __attribute__((deprecated("")));
		[Export("adDidProgressToTime:totalTime:")]
		void AdDidProgressToTime(double mediaTime, double totalTime);

		// @optional -(void)adsManagerAdPlaybackReady:(IMAAdsManager *)adsManager;
		[Export("adsManagerAdPlaybackReady:")]
		void AdsManagerAdPlaybackReady(IMAAdsManager adsManager);

		// @optional -(void)adsManagerAdDidStartBuffering:(IMAAdsManager *)adsManager;
		[Export("adsManagerAdDidStartBuffering:")]
		void AdsManagerAdDidStartBuffering(IMAAdsManager adsManager);

		// @optional -(void)adsManager:(IMAAdsManager *)adsManager adDidBufferToMediaTime:(NSTimeInterval)mediaTime;
		[Export("adsManager:adDidBufferToMediaTime:")]
		void AdsManager(IMAAdsManager adsManager, double mediaTime);
	}

	// @interface IMAAdsManager : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdsManager
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		IMAAdsManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<IMAAdsManagerDelegate> * _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSArray * adCuePoints;
		[Export("adCuePoints", ArgumentSemantic.Weak)]
		NSObject[] AdCuePoints { get; }

		// @property (readonly, nonatomic, strong) id<IMAAdPlaybackInfo> adPlaybackInfo;
		[Export("adPlaybackInfo", ArgumentSemantic.Strong)]
		IMAAdPlaybackInfo AdPlaybackInfo { get; }

		// -(void)initializeWithAdsRenderingSettings:(IMAAdsRenderingSettings *)adsRenderingSettings;
		[Export("initializeWithAdsRenderingSettings:")]
		void InitializeWithAdsRenderingSettings([NullAllowed] IMAAdsRenderingSettings adsRenderingSettings);

		// -(void)initializeWithContentPlayhead:(NSObject<IMAContentPlayhead> *)contentPlayhead adsRenderingSettings:(IMAAdsRenderingSettings *)adsRenderingSettings __attribute__((deprecated("")));
		[Export("initializeWithContentPlayhead:adsRenderingSettings:")]
		void InitializeWithContentPlayhead(IMAContentPlayhead contentPlayhead, [NullAllowed] IMAAdsRenderingSettings adsRenderingSettings);


		// -(instancetype)initWithAdTagUrl:(NSString *)adTagUrl adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer userContext:(id)userContext __attribute__((deprecated("")));
		/*	[Export("initializeWithContentPlayhead:adsRenderingSettings:")]
		IntPtr Constructor(IMAContentPlayhead contentPlayhead, [NullAllowed] IMAAdsRenderingSettings adsRenderingSettings);*/

		// -(void)start;
		[Export("start")]
		void Start();

		// -(void)pause;
		[Export("pause")]
		void Pause();

		// -(void)resume;
		[Export("resume")]
		void Resume();

		// -(void)skip;
		[Export("skip")]
		void Skip();

		// -(void)destroy;
		[Export("destroy")]
		void Destroy();

		// -(void)discardAdBreak;
		[Export("discardAdBreak")]
		void DiscardAdBreak();
	}

	// @protocol IMAWebOpenerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAWebOpenerDelegate
	{
		// @optional -(void)webOpenerWillOpenExternalBrowser:(NSObject *)webOpener;
		[Export("webOpenerWillOpenExternalBrowser:")]
		void WebOpenerWillOpenExternalBrowser(NSObject webOpener);

		// @optional -(void)webOpenerWillOpenInAppBrowser:(NSObject *)webOpener;
		[Export("webOpenerWillOpenInAppBrowser:")]
		void WebOpenerWillOpenInAppBrowser(NSObject webOpener);

		// @optional -(void)webOpenerDidOpenInAppBrowser:(NSObject *)webOpener;
		[Export("webOpenerDidOpenInAppBrowser:")]
		void WebOpenerDidOpenInAppBrowser(NSObject webOpener);

		// @optional -(void)webOpenerWillCloseInAppBrowser:(NSObject *)webOpener;
		[Export("webOpenerWillCloseInAppBrowser:")]
		void WebOpenerWillCloseInAppBrowser(NSObject webOpener);

		// @optional -(void)webOpenerDidCloseInAppBrowser:(NSObject *)webOpener;
		[Export("webOpenerDidCloseInAppBrowser:")]
		void WebOpenerDidCloseInAppBrowser(NSObject webOpener);

		// @optional -(void)willOpenExternalBrowser __attribute__((deprecated("")));
		[Export("willOpenExternalBrowser")]
		void WillOpenExternalBrowser();

		// @optional -(void)willOpenInAppBrowser __attribute__((deprecated("")));
		[Export("willOpenInAppBrowser")]
		void WillOpenInAppBrowser();

		// @optional -(void)didOpenInAppBrowser __attribute__((deprecated("")));
		[Export("didOpenInAppBrowser")]
		void DidOpenInAppBrowser();

		// @optional -(void)willCloseInAppBrowser __attribute__((deprecated("")));
		[Export("willCloseInAppBrowser")]
		void WillCloseInAppBrowser();

		// @optional -(void)didCloseInAppBrowser __attribute__((deprecated("")));
		[Export("didCloseInAppBrowser")]
		void DidCloseInAppBrowser();
	}

	// @interface IMAAdsRenderingSettings : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAAdsRenderingSettings
	{
		// @property (copy, nonatomic) NSArray * mimeTypes;
		[Export("mimeTypes", ArgumentSemantic.Copy)]
		NSObject[] MimeTypes { get; set; }

		// @property (nonatomic) int bitrate;
		[Export("bitrate")]
		int Bitrate { get; set; }

		// @property (copy, nonatomic) NSArray * uiElements;
		[Export("uiElements", ArgumentSemantic.Copy)]
		NSObject[] UiElements { get; set; }

		// @property (nonatomic, weak) UIViewController * _Nullable webOpenerPresentingController;
		[NullAllowed, Export("webOpenerPresentingController", ArgumentSemantic.Weak)]
		UIViewController WebOpenerPresentingController { get; set; }

		[Wrap("WeakWebOpenerDelegate")]
		[NullAllowed]
		IMAWebOpenerDelegate WebOpenerDelegate { get; set; }

		// @property (nonatomic, weak) id<IMAWebOpenerDelegate> _Nullable webOpenerDelegate;
		[NullAllowed, Export("webOpenerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakWebOpenerDelegate { get; set; }
	}

	// @interface IMAAdsRequest : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdsRequest
	{
		// @property (readonly, copy, nonatomic) NSString * adTagUrl;
		[Export("adTagUrl")]
		string AdTagUrl { get; }

		// @property (readonly, nonatomic, strong) IMAAdDisplayContainer * adDisplayContainer;
		[Export("adDisplayContainer", ArgumentSemantic.Strong)]
		IMAAdDisplayContainer AdDisplayContainer { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }

		// @property (nonatomic) BOOL adWillAutoPlay;
		[Export("adWillAutoPlay")]
		bool AdWillAutoPlay { get; set; }

		// -(instancetype)initWithAdTagUrl:(NSString *)adTagUrl adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer avPlayerVideoDisplay:(IMAAVPlayerVideoDisplay *)avPlayerVideoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy userContext:(id)userContext;
		[Export("initWithAdTagUrl:adDisplayContainer:avPlayerVideoDisplay:pictureInPictureProxy:userContext:")]
		IntPtr Constructor(string adTagUrl, IMAAdDisplayContainer adDisplayContainer, IMAAVPlayerVideoDisplay avPlayerVideoDisplay, IMAPictureInPictureProxy pictureInPictureProxy, NSObject userContext);

		// -(instancetype)initWithAdTagUrl:(NSString *)adTagUrl adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer contentPlayhead:(NSObject<IMAContentPlayhead> *)contentPlayhead userContext:(id)userContext __attribute__((objc_designated_initializer));
		[Export("initWithAdTagUrl:adDisplayContainer:contentPlayhead:userContext:")]
		[DesignatedInitializer]
		IntPtr Constructor(string adTagUrl, IMAAdDisplayContainer adDisplayContainer, IMAContentPlayhead contentPlayhead, [NullAllowed] NSObject userContext);

		// -(instancetype)initWithAdTagUrl:(NSString *)adTagUrl adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer userContext:(id)userContext __attribute__((deprecated("")));
		[Export("initWithAdTagUrl:adDisplayContainer:userContext:")]
		IntPtr Constructor(string adTagUrl, IMAAdDisplayContainer adDisplayContainer, [NullAllowed] NSObject userContext);
	}

	// @protocol IMACompanionDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMACompanionDelegate
	{
		// @optional -(void)companionSlot:(IMACompanionAdSlot *)slot filled:(BOOL)filled;
		[Export("companionSlot:filled:")]
		void Filled(IMACompanionAdSlot slot, bool filled);
	}

	// @interface IMACompanionAdSlot : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMACompanionAdSlot
	{
		// @property (readonly, nonatomic, strong) UIView * view;
		[Export("view", ArgumentSemantic.Strong)]
		UIView View { get; }

		// @property (readonly, nonatomic) int width;
		[Export("width")]
		int Width { get; }

		// @property (readonly, nonatomic) int height;
		[Export("height")]
		int Height { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		IMACompanionDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<IMACompanionDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype)initWithView:(UIView *)view width:(int)width height:(int)height;
		[Export("initWithView:width:height:")]
		IntPtr Constructor(UIView view, int width, int height);
	}

	// @interface IMAPictureInPictureProxy : NSProxy <AVPictureInPictureControllerDelegate, AVPlayerViewControllerDelegate>
	[BaseType(typeof(NSObject))]
	interface IMAPictureInPictureProxy : IAVPictureInPictureControllerDelegate, IAVPlayerViewControllerDelegate
	{
		// @property (readonly, getter = isPictureInPictureActive, nonatomic) BOOL pictureInPictureActive;
		[Export("pictureInPictureActive")]
		bool PictureInPictureActive { [Bind("isPictureInPictureActive")] get; }

		// +(BOOL)isPictureInPictureSupported;
		[Static]
		[Export("isPictureInPictureSupported")]
		bool IsPictureInPictureSupported { get; }

		// -(instancetype)initWithAVPictureInPictureControllerDelegate:(id<AVPictureInPictureControllerDelegate>)delegate;
		[Export("initWithAVPictureInPictureControllerDelegate:")]
		IntPtr Constructor(AVPictureInPictureControllerDelegate @delegate);

		// -(instancetype)initWithAVPlayerViewControllerDelegate:(id<AVPlayerViewControllerDelegate>)delegate;
		[Export("initWithAVPlayerViewControllerDelegate:")]
		IntPtr Constructor(AVPlayerViewControllerDelegate @delegate);
	}

	// @interface IMASettings : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface IMASettings : INSCopying
	{
		// @property (copy, nonatomic) NSString * ppid;
		[Export("ppid")]
		string Ppid { get; set; }

		// @property (copy, nonatomic) NSString * language;
		[Export("language")]
		string Language { get; set; }

		// @property (nonatomic) NSUInteger maxRedirects;
		[Export("maxRedirects")]
		nuint MaxRedirects { get; set; }

		// @property (nonatomic) BOOL enableBackgroundPlayback;
		[Export("enableBackgroundPlayback")]
		bool EnableBackgroundPlayback { get; set; }

		// @property (nonatomic) BOOL autoPlayAdBreaks;
		[Export("autoPlayAdBreaks")]
		bool AutoPlayAdBreaks { get; set; }

		// @property (copy, nonatomic) NSString * playerType;
		[Export("playerType")]
		string PlayerType { get; set; }

		// @property (copy, nonatomic) NSString * playerVersion;
		[Export("playerVersion")]
		string PlayerVersion { get; set; }

		// @property (nonatomic) BOOL enableDebugMode;
		[Export("enableDebugMode")]
		bool EnableDebugMode { get; set; }
	}

	// @protocol IMAStreamManagerDelegate
	[BaseType(typeof(NSObject))]
	[Model]
	interface IMAStreamManagerDelegate
	{
		// @required -(void)streamManager:(IMAStreamManager *)streamManager didReceiveAdEvent:(IMAAdEvent *)event;
		[Abstract]
		[Export("streamManager:didReceiveAdEvent:")]
		void DidReceiveAdEvent(IMAStreamManager streamManager, IMAAdEvent @event);

		// @required -(void)streamManager:(IMAStreamManager *)streamManager didReceiveAdError:(IMAAdError *)error;
		[Abstract]
		[Export("streamManager:didReceiveAdError:")]
		void DidReceiveAdError(IMAStreamManager streamManager, IMAAdError error);

		// @optional -(void)streamManager:(IMAStreamManager *)streamManager adDidProgressToTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)totalTime;
		[Export("streamManager:adDidProgressToTime:totalTime:")]
		void AdDidProgressToTime(IMAStreamManager streamManager, double mediaTime, double totalTime);
	}

	// @interface IMAStreamManager : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAStreamManager
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		IMAStreamManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<IMAStreamManagerDelegate> * _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * streamId;
		[Export("streamId")]
		string StreamId { get; }

		// -(void)initializeWithAdsRenderingSettings:(IMAAdsRenderingSettings *)adsRenderingSettings;
		[Export("initializeWithAdsRenderingSettings:")]
		void InitializeWithAdsRenderingSettings(IMAAdsRenderingSettings adsRenderingSettings);
	}

	// @interface IMAStreamRequest : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAStreamRequest
	{
		// @property (readonly, copy, nonatomic) NSString * assetKey;
		[Export("assetKey")]
		string AssetKey { get; }

		// @property (readonly, copy, nonatomic) NSString * contentSourceId;
		[Export("contentSourceId")]
		string ContentSourceId { get; }

		// @property (readonly, copy, nonatomic) NSString * videoId;
		[Export("videoId")]
		string VideoId { get; }

		// @property (readonly, copy, nonatomic) NSString * assetType;
		[Export("assetType")]
		string AssetType { get; }

		// @property (readonly, nonatomic, strong) IMAAdDisplayContainer * adDisplayContainer;
		[Export("adDisplayContainer", ArgumentSemantic.Strong)]
		IMAAdDisplayContainer AdDisplayContainer { get; }

		// @property (readonly, nonatomic, strong) id<IMAVideoDisplay> videoDisplay;
		[Export("videoDisplay", ArgumentSemantic.Strong)]
		IIMAVideoDisplay VideoDisplay { get; }

		// @property (copy, nonatomic) NSString * apiKey;
		[Export("apiKey")]
		string ApiKey { get; set; }

		// @property (copy, nonatomic) NSDictionary * customParameters;
		[Export("customParameters", ArgumentSemantic.Copy)]
		NSDictionary CustomParameters { get; set; }

		// @property (nonatomic) BOOL attemptPreroll;
		[Export("attemptPreroll")]
		bool AttemptPreroll { get; set; }

		// -(instancetype)initWithAssetKey:(NSString *)assetKey adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay;
		[Export("initWithAssetKey:adDisplayContainer:videoDisplay:")]
		IntPtr Constructor(string assetKey, IMAAdDisplayContainer adDisplayContainer, IIMAVideoDisplay videoDisplay);

		// -(instancetype)initWithContentSourceId:(NSString *)contentSourceId videoId:(NSString *)videoId adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay;
		[Export("initWithContentSourceId:videoId:adDisplayContainer:videoDisplay:")]
		IntPtr Constructor(string contentSourceId, string videoId, IMAAdDisplayContainer adDisplayContainer, IIMAVideoDisplay videoDisplay);
	}
}
