using Assets.Scripts.UI.Menu.Effects;
using UnityEngine;

namespace Assets.Scripts.UI.Menu
{
    [RequireComponent(typeof(MenuMover))]
    public class MenuManager : MonoBehaviour
    {
        private MenuMover menuMover;
        private int currentMenu = 1;
        private IMenu[] menus;

        private void Awake()
        {
            menuMover = GetComponent<MenuMover>();
            menus = GetComponentsInChildren<IMenu>()
                ;
        }

        public void GoToNextMenu()
        {
            currentMenu++;
            menuMover.GoToNextMenu();
        }

        public void GoToPreviousMenu()
        {
            menuMover.GoToPreviousMenu();
        }
    }
}
