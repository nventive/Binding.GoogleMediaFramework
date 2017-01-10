using System;
using AVFoundation;
using AVKit;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace GoogleMediaFramework
{
	public enum CurrentPlayPauseReplayIcon : uint
	{
		Play,
		Pause,
		Replay
	}

	public enum GMFPlayerState : uint
	{
		Empty = 0,
		LoadingContent,
		ReadyToPlay,
		Playing,
		Paused,
		Buffering,
		Seeking,
		Finished,
		Error
	}

	public enum GMFPlayerFinishReason : uint
	{
		PlaybackEnded = 0,
		PlaybackError,
		UserExited
	}
	[Native]
	public enum IMAErrorType : ulong
	{
		UnknownErrorType,
		LoadingFailed,
		PlayingFailed
	}

	[Native]
	public enum IMAErrorCode : ulong
	{
		VastMalformedResponse = 100,
		UnknownAdResponse = 200,
		VastLoadTimeout = 301,
		VastTooManyRedirects = 302,
		VastInvalidUrl = 303,
		VideoPlayError = 400,
		VastMediaLoadTimeout = 402,
		VastLinearAssetMismatch = 403,
		CompanionAdLoadingFailed = 603,
		UnknownError = 900,
		PlaylistMalformedResponse = 1004,
		FailedToRequestAds = 1005,
		RequiredListenersNotAdded = 1006,
		VastAssetNotFound = 1007,
		AdslotNotVisible = 1008,
		VastEmptyResponse = 1009,
		FailedLoadingAd = 1010,
		StreamInitializationFailed = 1020,
		InvalidArguments = 1101,
		ApiError = 1102,
		IosRuntimeTooOld = 1103,
		VideoElementUsed = 1201,
		VideoElementRequired = 1202,
		ContentPlayheadMissing = 1205
	}

	[Native]
	public enum IMAAdEventType : ulong
	{
		AdBreakReady,
		AdBreakEnded,
		AdBreakStarted,
		AllAdsCompleted,
		Clicked,
		Complete,
		FirstQuartile,
		Loaded,
		Midpoint,
		Pause,
		Resume,
		Skipped,
		Started,
		Tapped,
		ThirdQuartile
	}

	[Native]
	public enum IMAUiElementType : ulong
	{
		AdAttribution,
		Countdown
	}
}

