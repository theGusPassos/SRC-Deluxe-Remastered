using UnityEngine;

namespace Assets.Scripts.InputInterface
{
    public static class MenuInputInterface
    {
        public static bool GetStartInput() => Input.GetButtonDown("start");
        public static float GetVerticalInput() => Input.GetAxisRaw("Vertical");
    }
}
