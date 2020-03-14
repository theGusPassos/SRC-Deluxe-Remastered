using Assets.Scripts.InputInterface;
using Assets.Scripts.UI.Menu.Effects;
using UnityEngine;

namespace Assets.Scripts.UI.Menu
{
    public class BaseMenu : MonoBehaviour, IMenu
    {
        protected MenuManager menuManager;
        private bool inputDown = false;
        [SerializeField] private int optionCount;
        private CircularSum circularSum;
        private OptionMover optionMover;

        protected int CurrentOption { get; private set; }

        [SerializeField] private bool startAsActive;
        public bool IsActive { get; set; }

        private void Awake()
        {
            menuManager = GetComponentInParent<MenuManager>();
            optionMover = GetComponentInChildren<OptionMover>();

            circularSum = new CircularSum(optionCount - 1);

            IsActive = startAsActive;
        }

        protected virtual void Update()
        {
            if (!IsActive) return;

            if (optionCount > 1)
                ChangeOption();

            SelectOption();
        }

        private void ChangeOption()
        {
            var input = MenuInputInterface.GetVerticalInput();

            if (!inputDown && Mathf.Abs(input) > InputConfiguration.instance.AxisSensibilityInMeny)
            {
                inputDown = true;

                if (input > 0)
                    GoToPreviousOption();

                else if (input < 0)
                    GoToNextOption();
            }

            if (input == 0) inputDown = false;
        }

        private void GoToNextOption()
        {
            if (CurrentOption < optionCount - 1)
            {
                CurrentOption++;
                optionMover.MoveDown();
            }
        }

        private void GoToPreviousOption()
        {
            if (CurrentOption - 1 >= 0)
            {
                CurrentOption--;
                optionMover.MoveUp();
            }
        }

        private void SelectOption()
        {
            if (MenuInputInterface.GetMenuConfirmationInput())
            {
                OnOptionSelected();
            }
        }

        protected virtual void OnOptionSelected() { }
    }
}
