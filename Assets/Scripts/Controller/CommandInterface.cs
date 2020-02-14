using UnityEngine;

namespace Assets.Scripts.Controller
{
    public static class CommandInterface
    {
        public static float GetHorizontalInput()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public static float GetVerticalInput()
        {
            return Input.GetAxisRaw("Vertical");
        }
    }
}
