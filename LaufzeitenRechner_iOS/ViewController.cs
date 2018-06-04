using System;
using UIKit;

namespace LaufzeitenRechner_iOS {
    public partial class ViewController : UIViewController {
        private int totalTimeInSeconds, secondsPerKilometer;

        private double runDistance;

        private bool isDistanceGiven, isTotalTimeGiven, isPaceGiven;

        private void calculateButton_TouchDown(object sender, EventArgs eventArgs) {
            isDistanceGiven = false;
            isTotalTimeGiven = false;
            isPaceGiven = false;

            if (distance.Text != string.Empty) isDistanceGiven = true;
            if (totalTimeHours.Text != string.Empty || totalTimeMinutes.Text != string.Empty || totalTimeSeconds.Text != string.Empty) isTotalTimeGiven = true;
            if (paceMinutes.Text != string.Empty || paceSeconds.Text != string.Empty) isPaceGiven = true;

            if (isDistanceGiven && isTotalTimeGiven && isPaceGiven) {
                showDialogBox("Zu viele Parameter", "Es genügt zwei der drei möglichen Werte einzugeben!");
                return;
                }

            if (!(isDistanceGiven && isTotalTimeGiven) && !(isDistanceGiven && isPaceGiven) && !(isTotalTimeGiven && isPaceGiven)) {
                showDialogBox("Zu wenige Parameter", "Es müssen zwei der drei möglichen Werte eingegeben werden, um eine Berechnung durchzuführen!");
                return;
                }

            try {
                if (isDistanceGiven) runDistance = Convert.ToDouble(distance.Text);

                if (isTotalTimeGiven) {
                    totalTimeInSeconds = 0;

                    if (totalTimeSeconds.Text != string.Empty) totalTimeInSeconds += Convert.ToInt32(totalTimeSeconds.Text);
                    if (totalTimeMinutes.Text != string.Empty) totalTimeInSeconds += 60 * Convert.ToInt32(totalTimeMinutes.Text);
                    if (totalTimeHours.Text != string.Empty) totalTimeInSeconds += 3600 * Convert.ToInt32(totalTimeHours.Text);
                    }

                if (isPaceGiven) {
                    secondsPerKilometer = 0;

                    if (paceSeconds.Text != string.Empty) secondsPerKilometer += Convert.ToInt32(paceSeconds.Text);
                    if (paceMinutes.Text != string.Empty) secondsPerKilometer += 60 * Convert.ToInt32(paceMinutes.Text);
                    }
                }
            catch (FormatException) {
                showDialogBox("Format Exception", "Mindestens ein eingegebener Wert entspricht nicht dem passenden Format!");
                return;
                }
            catch (OverflowException) {
                showDialogBox("Overflow Exception", "Mindestens ein eingegebener Wert über- bzw. unterschreitet die UInt Ober- bzw. Untergrenze!");
                return;
                }

            if (isDistanceGiven && isTotalTimeGiven) {
                secondsPerKilometer = (int)(totalTimeInSeconds / runDistance);

                paceMinutes.Text = string.Format("{0}", secondsPerKilometer / 60);
                paceSeconds.Text = string.Format("{0}", secondsPerKilometer % 60);
                }
            else if (isDistanceGiven && isPaceGiven) {
                totalTimeInSeconds = (int)(secondsPerKilometer * runDistance);

                if (totalTimeInSeconds / 3600 >= 1) totalTimeHours.Text = string.Format("{0}", totalTimeInSeconds / 3600);
                else totalTimeHours.Text = string.Empty;

                if ((totalTimeInSeconds % 3600) / 60 >= 1) totalTimeMinutes.Text = string.Format("{0}", (totalTimeInSeconds % 3600) / 60);
                else totalTimeMinutes.Text = string.Empty;

                if ((totalTimeInSeconds % 3600) % 60 > 0) totalTimeSeconds.Text = string.Format("{0}", (totalTimeInSeconds % 3600) % 60);
                else totalTimeSeconds.Text = string.Empty;
                }
            else distance.Text = string.Format("{0:F2}", (double)totalTimeInSeconds / secondsPerKilometer);

            speed.Text = string.Format("{0:F2}", (double)3600 / secondsPerKilometer);
            }

        private void deleteButton_TouchDown(object sender, EventArgs eventArgs) {
            distance.Text = string.Empty;
            totalTimeHours.Text = string.Empty;
            totalTimeMinutes.Text = string.Empty;
            totalTimeSeconds.Text = string.Empty;
            paceMinutes.Text = string.Empty;
            paceSeconds.Text = string.Empty;
            speed.Text = "[km/h]";
            }

        private void showDialogBox(string title, string message) {
            UIAlertView alert = new UIAlertView(title, message, null, "OK");
            alert.Show();
            }

        protected ViewController(IntPtr handle) : base(handle) {
            // Note: this .ctor should not contain any initialization logic.
            }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            calculationButton.TouchDown += calculateButton_TouchDown;
            deleteButton.TouchDown += deleteButton_TouchDown;
            }

        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
            }
        }
    }
