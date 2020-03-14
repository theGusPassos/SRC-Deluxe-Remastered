using Assets.Scripts.UI.Menu;

public class StartMenu : BaseMenu
{
    protected override void OnOptionSelected()
    {
        if (CurrentOption == 0)
            menuManager.GoToNextMenu();
        else
            menuManager.GoToPreviousMenu();
    }
}