// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LaufzeitenRechner
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSTextField distance { get; set; }

        [Outlet]
        AppKit.NSTextField paceMinutes { get; set; }

        [Outlet]
        AppKit.NSTextField paceSeconds { get; set; }

        [Outlet]
        AppKit.NSTextField speed { get; set; }

        [Outlet]
        AppKit.NSTextField totalTimeHours { get; set; }

        [Outlet]
        AppKit.NSTextField totalTimeMinutes { get; set; }

        [Outlet]
        AppKit.NSTextField totalTimeSeconds { get; set; }

        [Action ("clickedCalculationButton:")]
        partial void clickedCalculationButton (Foundation.NSObject sender);

        [Action ("clickedDeleteButton:")]
        partial void clickedDeleteButton (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (distance != null) {
                distance.Dispose ();
                distance = null;
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
