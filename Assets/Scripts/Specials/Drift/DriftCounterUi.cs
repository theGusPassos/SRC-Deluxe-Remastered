using Assets.Scripts.Utilities;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Specials.Drift
{
    [RequireComponent(typeof(ObjectFollowerFromCanvas))]
    public class DriftCounterUi : MonoBehaviour 
    {
        [SerializeField] private TextMeshProUGUI driftCounter;
        [SerializeField] private TextMeshProUGUI driftMultiplier;

        private ObjectFollowerFromCanvas objectFollower;

        private void Awake()
        {
            objectFollower = GetComponent<ObjectFollowerFromCanvas>();
        }

        public void SetCarToFollow(Transform car) => objectFollower.SetObjectToFollow(car);

        public void SetCurrentPointsInDrift(float currentPointsInDrift)
        {
            driftCounter.text = ((int)currentPointsInDrift).ToString();
        }

        public void SetMultiplier(int multiplier)
        {
            driftMultiplier.text = $"x {multiplier}";
        }
    }
}
