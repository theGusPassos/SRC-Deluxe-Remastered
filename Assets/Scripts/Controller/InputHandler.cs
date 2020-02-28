using Assets.Scripts.InputInterface;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private CarController carController;

        private void Update()
        {
            float horizontalInput = CarInputInterface.GetHorizontalInput();
            float verticalInput = CarInputInterface.GetVerticalInput();

            float acceleratingInput = CarInputInterface.GetAcceleratingInput();
            float breakInput = CarInputInterface.GetBreakInput();

            carController.MoveCar(horizontalInput, acceleratingInput >= 0 ? acceleratingInput : 0, breakInput);

            if (CarInputInterface.GetHandBreakInput())
                carController.HandBreak(horizontalInput);

            if (CarInputInterface.GetHandBreakInputUp())
                carController.ReleaseHandBreak();
        }
    }
}
