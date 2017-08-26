namespace ServoTest_BP2
{
    class Program
    {
        private double _speedRotation;

        public void BrainPadSetup()
        {
            //Put your setup code here. It runs once when the BrainPad starts up.
            _speedRotation = 0;
            BrainPad.Display.DrawTextAndShowOnScreen(0, 0, "Hello!");
            BrainPad.ServoMotors.ServoOne.ConfigurePulseParameters(0.7, 2.3);
            BrainPad.ServoMotors.ServoOne.ConfigureAsContinuous(true);
            BrainPad.ServoMotors.ServoOne.Set(_speedRotation);
            BrainPad.Buttons.WhenLeftButtonPressed += Buttons_WhenLeftButtonPressed;
            BrainPad.Buttons.WhenDownButtonPressed += Buttons_WhenDownButtonPressed;
            BrainPad.Buttons.WhenRightButtonPressed += Buttons_WhenRightButtonPressed;
            BrainPad.Buttons.WhenUpButtonPressed += Buttons_WhenUpButtonPressed;
            DisplaySpeed();
        }

        private void Buttons_WhenUpButtonPressed()
        {
            BrainPad.ServoMotors.ServoOne.Set(_speedRotation);
            DisplaySpeed();
        }

        private void Buttons_WhenRightButtonPressed()
        {
            _speedRotation += 10;
            if (_speedRotation > 100)
                _speedRotation = 100;

            // BrainPad.ServoMotors.ServoOne.Stop();
            BrainPad.ServoMotors.ServoOne.Set(_speedRotation);
            DisplaySpeed();
        }

        private void Buttons_WhenDownButtonPressed()
        {
            BrainPad.ServoMotors.ServoOne.Stop();
            DisplaySpeed();
        }

        private void DisplaySpeed()
        {
            BrainPad.Display.DrawTextAndShowOnScreen(0, 20, "Speed:" + _speedRotation);
        }

        private void Buttons_WhenLeftButtonPressed()
        {
            _speedRotation -= 10;
            if (_speedRotation < -100)
                _speedRotation = -100;

            // BrainPad.ServoMotors.ServoOne.Stop();
            BrainPad.ServoMotors.ServoOne.Set(_speedRotation);
            DisplaySpeed();
        }

        public void BrainPadLoop()
        {
            //Put your program code here. It runs repeatedly after the BrainPad starts up.

            BrainPad.LightBulb.TurnBlue();
            BrainPad.Wait.Seconds(1);
            BrainPad.LightBulb.TurnOff();
            BrainPad.Wait.Seconds(1);
        }
    }
}
