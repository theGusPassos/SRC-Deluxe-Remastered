using UnityEngine;

namespace Assets.Scripts.Specials.Drift
{
    public class DriftConfiguration : MonoBehaviour
    {
        public static DriftConfiguration instance;

        [SerializeField] private float driftPointsByTime;
        [SerializeField] private float[] driftMultiplierMinTime;
        [SerializeField] private int driftCounterFloaterPoolSize;

        public float DriftPointsByTime  { get => driftPointsByTime; }
        public float[] DriftMultiplierMinTime { get => driftMultiplierMinTime; }
        public int DriftCounterFloaterPoolSize { get => driftCounterFloaterPoolSize; }

        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            instance = this;
        }
    }
}
