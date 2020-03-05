using Assets.Scripts.Systems;
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
        [SerializeField] private Vector3 distanceFromCar;

        [SerializeField] private GameObject driftCounterFloaterPrefab;
        private ObjectPool<DriftCounterFloater> driftCounterFloaterPool;

        private ObjectFollowerFromCanvas objectFollower;

        private void Awake()
        {
            objectFollower = GetComponent<ObjectFollowerFromCanvas>();
        }

        private void Start()
        {
            driftCounterFloaterPool = new ObjectPool<DriftCounterFloater>(
                DriftConfiguration.instance.DriftCounterFloaterPoolSize,
                driftCounterFloaterPrefab);
        }

        public void SetCarToFollow(Transform car) 
        {
            objectFollower.SetDistanceFromTarget(distanceFromCar);
            objectFollower.SetObjectToFollow(car); 
        }

        public void StartUi()
        {
            driftCounter.enabled = true;
            driftMultiplier.enabled = true;
            driftMultiplier.text = "";
        }

        public void SetCurrentPointsInDrift(float currentPointsInDrift)
        {
            driftCounter.text = currentPointsInDrift.ToString("N0");
        }

        public void SetMultiplier(int multiplier)
        {
            driftMultiplier.text = $"x {multiplier}";
        }

        public void ResetUi()
        {
            driftCounter.enabled = false;
            driftMultiplier.enabled = false;

            CreateScoreFloater();
        }

        public void CreateScoreFloater()
        {
            var driftCounterFloater = driftCounterFloaterPool.PlaceObject(transform.position, transform.parent);
            driftCounterFloater.SetFloater(driftCounter.text, driftMultiplier.text);
        }
    }
}
