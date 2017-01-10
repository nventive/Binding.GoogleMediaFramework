using System;
using ObjCRuntime;

[assembly: LinkWith("libGoogleMediaFrameworkSDK.a", LinkTarget.Arm64 | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, SmartLink = false, ForceLoad = false, LinkerFlags = "-ObjC -w -v -lz", Frameworks = "AdSupport AudioToolbox AVFoundation SystemConfiguration CoreMedia WebKit QuartzCore MediaPlayer")]
