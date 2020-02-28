namespace Assets.Scripts.UI.Menu
{
    public class OptionsInMenu
    {
        private int optionCount;
        private int currentOption;

        public OptionsInMenu(int optionCount, int currentOption = 0)
        {
            this.optionCount = optionCount;
            this.currentOption = currentOption;
        }

        public int GetCurrentOption() => currentOption;

        public int GetNextOption()
        {
            currentOption++;
            if (currentOption >= optionCount)
                currentOption = 0;

            return currentOption;
        }

        public int GetPreviousOption()
        {
            currentOption--;
            if (currentOption < 0)
                currentOption = optionCount - 1;

            return currentOption;
        }
    }
}
