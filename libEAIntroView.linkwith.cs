using System;
using ObjCRuntime;

[assembly: LinkWith ("libEAIntroView.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Simulator64, SmartLink = true, ForceLoad = true)]
