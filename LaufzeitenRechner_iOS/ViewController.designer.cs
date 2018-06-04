// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace LaufzeitenRechner_iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton calculationButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton deleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField distance { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView logo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField paceMinutes { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField paceSeconds { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel speed { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField totalTimeHours { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField totalTimeMinutes { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField totalTimeSeconds { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (calculationButton != null) {
                calculationButton.Dispose ();
                calculationButton = null;
            }

            if (deleteButton != null) {
                deleteButton.Dispose ();
                deleteButton = null;
            }

            if (distance != null) {
                distance.Dispose ();
                distance = null;
            }

            if (logo != null) {
                logo.Dispose ();
                logo = null;
            }

            if (paceMinutes != null) {
                paceMinutes.Dispose ();
                paceMinutes = null;
            }

            if (paceSeconds != null) {
                paceSeconds.Dispose ();
                paceSeconds = null;
            }

            if (speed != null) {
                speed.Dispose ();
                speed = null;
            }

            if (totalTimeHours != null) {
                totalTimeHours.Dispose ();
                totalTimeHours = null;
            }

            if (totalTimeMinutes != null) {
                totalTimeMinutes.Dispose ();
                totalTimeMinutes = null;
            }

            if (totalTimeSeconds != null) {
                totalTimeSeconds.Dispose ();
                totalTimeSeconds = null;
            }
        }
    }
}