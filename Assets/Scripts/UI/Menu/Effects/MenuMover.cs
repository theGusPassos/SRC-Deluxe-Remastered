using Assets.Scripts.Utilities.Movers;
using UnityEngine;

namespace Assets.Scripts.UI.Menu.Effects
{
    public class MenuMover : MonoBehaviour
    {
        [SerializeField] private GoToPosition[] menus;
        [SerializeField] private float menuDistance;
        private const int firstMenu = 1;
        private int currentMenu = firstMenu;

        private Vector3 middlePosition;
        private Vector3 topPosition;
        private Vector3 bottomPosition;

        private void Awake()
        {
            CalculatePositions();
            SetMenuStartPositions();
        }

        private void CalculatePositions()
        {
            Vector3 distance = new Vector3(0, menuDistance);

            middlePosition = menus[currentMenu].transform.position;
            topPosition = middlePosition + distance;
            bottomPosition = middlePosition - distance;
        }

        private void SetMenuStartPositions()
        {
            menus[currentMenu - 1].transform.position = topPosition;
            menus[currentMenu + 1].transform.position = bottomPosition;
        }

        public void GoToNextMenu()
        {
            if (currentMenu < menus.Length - 1)
            {
                menus[currentMenu].SetPositionToGo(topPosition);
                menus[++currentMenu].SetPositionToGo(middlePosition);
            }
        }

        public void GoToPreviousMenu()
        {
            if (currentMenu > 0)
            {
                menus[currentMenu].SetPositionToGo(bottomPosition);
                menus[--currentMenu].SetPositionToGo(middlePosition);
            }
        }
    }
}
