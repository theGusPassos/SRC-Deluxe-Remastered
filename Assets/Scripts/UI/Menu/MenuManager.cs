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
            menus = GetComponentsInChildren<IMenu>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                GoToNextMenu();
            else if (Input.GetKeyDown(KeyCode.M))
                GoToPreviousMenu();
        }

        public void GoToNextMenu()
        {
            if (currentMenu + 1 >= menus.Length)
                return;

            menus[currentMenu].IsActive = false;
            currentMenu++;
            menus[currentMenu].IsActive = true;

            menuMover.GoToNextMenu();
        }

        public void GoToPreviousMenu()
        {
            if (currentMenu - 1 < 0)
                return;

            menus[currentMenu].IsActive = false;
            currentMenu--;
            menus[currentMenu].IsActive = true;

            menuMover.GoToPreviousMenu();
        }
    }
}
