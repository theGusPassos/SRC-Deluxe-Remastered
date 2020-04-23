using Assets.Scripts.Utilities.Movers;
using UnityEngine;

namespace Assets.Scripts.UI.Menu.Effects
{
    public class MenuMover : MonoBehaviour
    {
        [SerializeField] private GoToPosition[] menus;
        [SerializeField] private Vector3 menuDistance;
        [SerializeField] private int currentMenu;

        private Vector3[] menuStartPositions;

        private void Awake()
        {
            CalculatePositions();
            SetMenuStartPositions();
        }

        private void CalculatePositions()
        {
            menuStartPositions = new Vector3[menus.Length];

            for (int i = 0; i < menuStartPositions.Length; i++)
            {
                if (i == currentMenu)
                {
                    menuStartPositions[i] = transform.position;
                }
                else
                {
                    menuStartPositions[i] = transform.position
                        + (i - currentMenu) * menuDistance;
                }
            }
        }

        private void SetMenuStartPositions()
        {
            for (int i = 0; i < menus.Length; i++)
            {
                menus[i].transform.position = menuStartPositions[i];
            }
        }

        public void GoToNextMenu()
        {
            if (currentMenu < menus.Length - 1)
            {
                menus[currentMenu].SetPositionToGo(menus[currentMenu].transform.position - menuDistance);
                menus[currentMenu + 1].SetPositionToGo(menus[currentMenu + 1].transform.position - menuDistance);
                currentMenu++;
            }
        }

        public void GoToPreviousMenu()
        {
            if (currentMenu > 0)
            {
                menus[currentMenu].SetPositionToGo(menus[currentMenu].transform.position + menuDistance);
                menus[currentMenu - 1].SetPositionToGo(menus[currentMenu - 1].transform.position + menuDistance);
                currentMenu--;
            }
        }
    }
}
