using Assets.Scripts.InputInterface;
using UnityEngine;

namespace Assets.Scripts.UI.Menu
{
    [RequireComponent(typeof(MenuMover))]
    public class MainMenu : MonoBehaviour
    {
        private bool inputDown = false;

        private MenuMover menuMover;

        private void Awake()
        {
            menuMover = GetComponent<MenuMover>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                menuMover.GoToNextMenu();
            }
            else if(Input.GetKeyDown(KeyCode.P))
            {
                menuMover.GoToPreviousMenu();
            }
        }

        private void ChangeOption()
        {
            var input = MenuInputInterface.GetVerticalInput();

            if (!inputDown 
                && Mathf.Abs(input) > InputConfiguration.instance.AxisSensibilityInMeny)
            {
                inputDown = true;
            }

            if (input == 0) inputDown = false;
        }

        private void SelectOption()
        {
            
        }
    }
}
