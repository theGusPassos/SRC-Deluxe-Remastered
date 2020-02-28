using Assets.Scripts.InputInterface;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Text[] optionsText;
        [SerializeField] private Color selectedOptionColor;
        [SerializeField] private Color notSelectedOptionColor;
        private OptionsInMenu options;

        private bool inputDown = false;

        private void Awake()
        {
            options = new OptionsInMenu(optionsText.Length);
            optionsText[options.GetCurrentOption()].color = selectedOptionColor;
        }

        private void Update()
        {
            var input = MenuInputInterface.GetVerticalInput();

            if (!inputDown 
                && Mathf.Abs(input) > InputConfiguration.instance.AxisSensibilityInMeny)
            {
                if (input > 0)
                    ChangeSelectedOption(options.GetCurrentOption(), options.GetNextOption());

                else if (input < 0)
                    ChangeSelectedOption(options.GetCurrentOption(), options.GetPreviousOption());

                inputDown = true;
            }

            if (input == 0) inputDown = false;
        }

        private void ChangeSelectedOption(int unselected, int selected)
        {
            optionsText[selected].color = selectedOptionColor;
            optionsText[unselected].color = notSelectedOptionColor;
        }
    }
}
