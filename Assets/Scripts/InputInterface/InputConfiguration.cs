using UnityEngine;

namespace Assets.Scripts.InputInterface
{
    public class InputConfiguration : MonoBehaviour
    {
        public static InputConfiguration instance;

        [SerializeField] private float axisSensibilityInMenu;

        public float AxisSensibilityInMeny { get => axisSensibilityInMenu; }

        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            instance = this;
        }
    }
}
