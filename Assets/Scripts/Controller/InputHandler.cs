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

            carController.Steer(horizontalInput);
            carController.Accelerate(acceleratingInput >= 0 ? acceleratingInput : 0);

            if (breakInput > 0)
                carController.Break(breakInput);
        }
    }
}
