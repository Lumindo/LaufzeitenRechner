using AppKit;
using Foundation;
using System;

namespace LaufzeitenRechner {
    public partial class ViewController : NSViewController {
        private int totalTimeInSeconds, secondsPerKilometer;

        private double runDistance;

        private bool isDistanceGiven, isTotalTimeGiven, isPaceGiven;

        private void showDialogBox(string message) {
            NSAlert alert = new NSAlert() {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = message,
                MessageText = "Achtung!"
                };

            alert.RunModal();
            }


        partial void clickedCalculationButton(NSObject sender) {
            isDistanceGiven = false;
            isTotalTimeGiven = false;
            isPaceGiven = false;

            if (distance.StringValue != string.Empty) isDistanceGiven = true;
            if (totalTimeHours.StringValue != string.Empty || totalTimeMinutes.StringValue != string.Empty || totalTimeSeconds.StringValue != string.Empty) isTotalTimeGiven = true;
            if (paceMinutes.StringValue != string.Empty || paceSeconds.StringValue != string.Empty) isPaceGiven = true;

            if (isDistanceGiven && isTotalTimeGiven && isPaceGiven) {
                showDialogBox("Es genügt zwei der drei möglichen Werte einzugeben!");
                return;
                }

            if (!(isDistanceGiven && isTotalTimeGiven) && !(isDistanceGiven && isPaceGiven) && !(isTotalTimeGiven && isPaceGiven)) {
                showDialogBox("Es müssen zwei der drei möglichen Werte eingegeben werden, um eine Berechnung durchzuführen!");
                return;
                }

            try {
                if (isDistanceGiven) runDistance = Convert.ToDouble(distance.StringValue);

                if (isTotalTimeGiven) {
                    totalTimeInSeconds = 0;

                    if (totalTimeSeconds.StringValue != string.Empty) totalTimeInSeconds += Convert.ToInt32(totalTimeSeconds.StringValue);
                    if (totalTimeMinutes.StringValue != string.Empty) totalTimeInSeconds += 60 * Convert.ToInt32(totalTimeMinutes.StringValue);
                    if (totalTimeHours.StringValue != string.Empty) totalTimeInSeconds += 3600 * Convert.ToInt32(totalTimeHours.StringValue);
                    }

                if (isPaceGiven) {
                    secondsPerKilometer = 0;

                    if (paceSeconds.StringValue != string.Empty) secondsPerKilometer += Convert.ToInt32(paceSeconds.StringValue);
                    if(paceMinutes.StringValue != string.Empty) secondsPerKilometer += 60 * Convert.ToInt32(paceMinutes.StringValue);
                    }
                }
            catch(FormatException) {
                showDialogBox("Mindestens ein eingegebener Wert entspricht nicht dem passenden Format!");
                return;
                }
            catch(OverflowException) {
                showDialogBox("Mindestens ein eingegebener Wert über- bzw. unterschreitet die UInt Ober- bzw. Untergrenze!");
                return;
                }

            if(isDistanceGiven && isTotalTimeGiven) {
                secondsPerKilometer = (int)(totalTimeInSeconds / runDistance);

                paceMinutes.StringValue = string.Format("{0}", secondsPerKilometer / 60);
                paceSeconds.StringValue = string.Format("{0}", secondsPerKilometer % 60);
                }
            else if(isDistanceGiven && isPaceGiven) {
                totalTimeInSeconds = (int)(secondsPerKilometer * runDistance);

                if (totalTimeInSeconds / 3600 >= 1) totalTimeHours.StringValue = string.Format("{0}", totalTimeInSeconds / 3600);
                else totalTimeHours.StringValue = string.Empty;

                if ((totalTimeInSeconds % 3600) / 60 >= 1) totalTimeMinutes.StringValue = string.Format("{0}", (totalTimeInSeconds % 3600) / 60);
                else totalTimeMinutes.StringValue = string.Empty;

                if ((totalTimeInSeconds % 3600) % 60 > 0) totalTimeSeconds.StringValue = string.Format("{0}", (totalTimeInSeconds % 3600) % 60);
                else totalTimeSeconds.StringValue = string.Empty;
                }
            else distance.StringValue = string.Format("{0:F2}", (double)totalTimeInSeconds / secondsPerKilometer);

            speed.StringValue = string.Format("{0:F2}", (double)3600 / secondsPerKilometer);
            }

        partial void clickedDeleteButton(NSObject sender) {
            distance.StringValue = string.Empty;
            totalTimeHours.StringValue = string.Empty;
            totalTimeMinutes.StringValue = string.Empty;
            totalTimeSeconds.StringValue = string.Empty;
            paceMinutes.StringValue = string.Empty;
            paceSeconds.StringValue = string.Empty;
            speed.StringValue = "[km/h]";
            }

        public ViewController(IntPtr handle) : base(handle) {
            }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            }

        public override NSObject RepresentedObject {
            get { return base.RepresentedObject; }
            set { base.RepresentedObject = value; }
            }
        }
    }
