using UnityEngine;

namespace Assets.Scripts.InputInterface
{
    public static class CarInputInterface
    {
        public static float GetHorizontalInput() => Input.GetAxisRaw("Horizontal");
        public static float GetVerticalInput() => Input.GetAxisRaw("Vertical");
        public static float GetAcceleratingInput() => Input.GetAxisRaw("R2");
        public static float GetBreakInput() => Input.GetAxisRaw("L2");
        public static bool GetHandBreakInput() => Input.GetButton("x");
        public static bool GetHandBreakInputUp() => Input.GetButtonUp("x");
    }
}
