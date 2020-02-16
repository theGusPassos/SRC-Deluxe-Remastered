using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private CarController carController;

        private void Update()
        {
            float horizontalInput = CommandInterface.GetHorizontalInput();
            float verticalInput = CommandInterface.GetVerticalInput();

            float acceleratingInput = CommandInterface.GetAcceleratingInput();
            float breakInput = CommandInterface.GetBreakInput();

            carController.MoveCar(horizontalInput, acceleratingInput >= 0 ? acceleratingInput : 0, breakInput);

            if (CommandInterface.GetHandBreakInput())
                carController.HandBreak(horizontalInput);

            if (CommandInterface.GetHandBreakInputUp())
                carController.ReleaseHandBreak();
        }
    }
}
