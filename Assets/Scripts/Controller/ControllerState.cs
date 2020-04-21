namespace Assets.Scripts.Controller
{
    public class ControllerState
    {
        public bool WaitingStartCountDown { get; set; }
        public bool IsInBattle { get; set; }

        public ControllerState()
        {
            WaitingStartCountDown = false;
            IsInBattle = false;
        }

        public bool CanMove => IsInBattle && !WaitingStartCountDown;
    }
}
