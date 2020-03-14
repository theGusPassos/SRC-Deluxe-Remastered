using Assets.Scripts.UI.Menu;
using UnityEngine;

public class GameModeMenu : BaseMenu
{
    protected override void OnOptionSelected()
    {
        if (CurrentOption == 0)
            Debug.Log("Starting game");
        else
            menuManager.GoToPreviousMenu();
    }
}