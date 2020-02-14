using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class InputHandler : MonoBehaviour
    {
        private void Update()
        {
            float horizontalInput = CommandInterface.GetHorizontalInput();
            float verticalInput = CommandInterface.GetVerticalInput();
        }
    }
}
