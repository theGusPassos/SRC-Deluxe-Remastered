using Assets.Scripts.UI.Menu;
using Assets.Scripts.UI.Menu.CarSelection;
using UnityEngine;

public class GameModeMenu : BaseMenu
{
    [SerializeField] private CarSelectionMenu carSelectionMenu;

    protected override void OnOptionSelected()
    {
        if (CurrentOption == 0)
        {
            GoToCarSelectionMenu();
        }
        else
            menuManager.GoToPreviousMenu();
    }

    private void GoToCarSelectionMenu()
    {
        carSelectionMenu.gameObject.SetActive(true);
        menuManager.gameObject.SetActive(false);
    }
}