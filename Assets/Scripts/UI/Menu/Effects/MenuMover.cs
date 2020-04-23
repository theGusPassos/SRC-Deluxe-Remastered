using Assets.Scripts.Utilities.Movers;
using UnityEngine;

namespace Assets.Scripts.UI.Menu.Effects
{
    public class MenuMover : MonoBehaviour
    {
        [SerializeField] private GoToPosition[] menus;
        [SerializeField] private Vector3 menuDistance;
        [SerializeField] private int currentMenu;

        private void Awake()
        {
            CalculatePositions();
        }

        private void CalculatePositions()
        {
            for (int i = 0; i < menus.Length; i++)
            {
                if (i == currentMenu)
                {
                    menus[i].transform.position = transform.position;
                }
                else
                {
                    menus[i].transform.position = transform.position
                        + (i - currentMenu) * menuDistance;
                }
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
