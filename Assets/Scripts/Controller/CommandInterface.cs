using UnityEngine;

namespace Assets.Scripts.Controller
{
    public static class CommandInterface
    {
        public static float GetHorizontalInput() => Input.GetAxisRaw("Horizontal");

        public static float GetVerticalInput() => Input.GetAxisRaw("Vertical");

        public static float GetAcceleratingInput() => Input.GetAxisRaw("R2");

        public static float GetBreakInput() => Input.GetAxisRaw("L2");
    }
}
