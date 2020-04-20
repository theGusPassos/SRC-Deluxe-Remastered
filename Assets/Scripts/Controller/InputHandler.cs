using Assets.Scripts.InputInterface;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    [RequireComponent(typeof(CarController))]
    public class InputHandler : MonoBehaviour
    {
        public CarController CarController { get; set; }

        private void Update()
        {
            float horizontalInput = CarInputInterface.GetHorizontalInput();
            float verticalInput = CarInputInterface.GetVerticalInput();

            float acceleratingInput = CarInputInterface.GetAcceleratingInput();
            float breakInput = CarInputInterface.GetBreakInput();

            CarController.MoveCar(horizontalInput, acceleratingInput >= 0 ? acceleratingInput : 0, breakInput);

            if (CarInputInterface.GetHandBreakInput())
                CarController.HandBreak(horizontalInput);

            if (CarInputInterface.GetHandBreakInputUp())
                CarController.ReleaseHandBreak();
        }
    }
}
