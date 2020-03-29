using UnityEngine;

namespace Assets.Scripts.InputInterface
{
    public static class MenuInputInterface
    {
        public static bool GetStartInput(string controllerId = "1") => Input.GetButtonDown($"start {controllerId}");
        public static float GetVerticalInput(string controllerId = "1") => Input.GetAxisRaw($"Vertical {controllerId}");
        public static bool GetMenuConfirmationInput(string controllerId = "1") => Input.GetButtonDown($"x {controllerId}") || Input.GetKeyDown(KeyCode.Return);
    }
}
