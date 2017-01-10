using System;
using ObjCRuntime;

[assembly: LinkWith("GoogleInteractiveMediaAds.a", LinkTarget.Arm64 | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, SmartLink = false, ForceLoad = false, LinkerFlags = "-ObjC -w -lz", Frameworks = "AdSupport AudioToolbox AVFoundation CoreFoundation CoreGraphics MessageUI SystemConfiguration CoreMedia WebKit UIKit MediaPlayer QuartzCore")]

