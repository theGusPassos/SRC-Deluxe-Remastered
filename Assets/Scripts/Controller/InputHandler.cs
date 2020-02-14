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

            carController.MoveCar(horizontalInput, 0, 0);
        }
    }
}
