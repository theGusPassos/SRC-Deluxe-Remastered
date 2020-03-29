using UnityEngine;

namespace Assets.Scripts.InputInterface
{
    public static class CarInputInterface
    {
        public static float GetHorizontalInput(string controllerId = "1") => Input.GetAxisRaw($"Horizontal {controllerId}");
        public static float GetVerticalInput(string controllerId = "1") => Input.GetAxisRaw($"Vertical {controllerId}");
        public static float GetAcceleratingInput(string controllerId = "1") => Input.GetAxisRaw($"R2 {controllerId}");
        public static float GetBreakInput(string controllerId = "1") => Input.GetAxisRaw($"L2 {controllerId}");
        public static bool GetHandBreakInput(string controllerId = "1") => Input.GetButton($"x {controllerId}");
        public static bool GetHandBreakInputUp(string controllerId = "1") => Input.GetButtonUp($"x {controllerId}");
    }
}
