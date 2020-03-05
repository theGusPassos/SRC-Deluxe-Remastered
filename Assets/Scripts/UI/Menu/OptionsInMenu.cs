namespace Assets.Scripts.UI.Menu
{
    public class OptionsInMenu
    {
        private readonly int optionCount;

        public OptionsInMenu(int optionCount, int currentOption = 0)
        {
            this.optionCount = optionCount;
            this.CurrentOption = currentOption;
        }

        public int CurrentOption { get; private set; }
        public int NextOption
        {
            get
            {
                CurrentOption++;
                if (CurrentOption >= optionCount) CurrentOption = 0;
                return CurrentOption;
            }
        }

        public int PreviousOption
        {
            get
            {
                CurrentOption--;
                if (CurrentOption < 0) CurrentOption = optionCount - 1;
                return CurrentOption;
            }
        }
    }
}
