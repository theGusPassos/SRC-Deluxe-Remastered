using Assets.Scripts.UI.Menu.Effects;
using UnityEngine;

namespace Assets.Scripts.UI.Menu
{
    [RequireComponent(typeof(MenuMover))]
    public class MenuManager : MonoBehaviour
    {
        private MenuMover menuMover;
        private int currentMenu = 1;
        private BaseMenu[] menus;

        private void Awake()
        {
            menuMover = GetComponent<MenuMover>();
            menus = GetComponentsInChildren<BaseMenu>();
        }

        private void Update()
        {
            menus[currentMenu].Execute();
        }

        public void GoToNextMenu()
        {
            if (currentMenu + 1 >= menus.Length)
                return;

            currentMenu++;
            menuMover.GoToNextMenu();
        }

        public void GoToPreviousMenu()
        {
            if (currentMenu - 1 < 0)
                return;

            currentMenu--;
            menuMover.GoToPreviousMenu();
        }
    }
}
