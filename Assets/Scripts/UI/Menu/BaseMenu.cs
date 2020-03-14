using Assets.Scripts.InputInterface;
using Assets.Scripts.UI.Menu.Effects;
using UnityEngine;

namespace Assets.Scripts.UI.Menu
{
    public class BaseMenu : MonoBehaviour, IMenu
    {
        private bool inputDown = false;
        [SerializeField] private int optionCount;
        private OptionMover optionMover;

        protected int CurrentOption { get; private set; }
        public bool IsActive { get; set; }

        private void Awake()
        {
            optionMover = GetComponentInChildren<OptionMover>();
        }

        protected virtual void Update()
        {
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
            if (CurrentOption + 1 < optionCount)
            {
                CurrentOption++;
                optionMover.MoveDown();
            }
            else
            {
                CurrentOption = 0;
                optionMover.MoveToFirst();
            }
        }

        private void GoToPreviousOption()
        {
            if (CurrentOption - 1 >= 0)
            {
                CurrentOption--;
                optionMover.MoveUp();
            }
            else
            {
                CurrentOption = optionCount - 1;
                optionMover.MoveToLast(optionCount);
            }
        }

        private void SelectOption()
        {
            if (MenuInputInterface.GetMenuConfirmationInput())
            {
                // OnOptionSelected();
            }
        }
    }
}
