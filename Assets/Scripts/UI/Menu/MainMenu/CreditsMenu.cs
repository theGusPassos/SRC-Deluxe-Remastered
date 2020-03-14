
using Assets.Scripts.UI.Menu;

public class CreditsMenu : BaseMenu
{
    protected override void OnOptionSelected()
    {
        menuManager.GoToNextMenu();
    }
}