using Assets.Scripts.Battle.Health;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Battl.Health
{
    public class HealthPoints : MonoBehaviour
    {
        [SerializeField] private GameObject healthPointsUiPrefab;
        [SerializeField] private float maxHealthPoints;
        private float currentHealthPoints;

        private void Awake()
        {
            currentHealthPoints = maxHealthPoints;
        }

        private void Start()
        {
            var hpUiObject = Instantiate(healthPointsUiPrefab);
            hpUiObject.name = $"Health Points Ui {gameObject.name}";

            var objectFollower = hpUiObject.GetComponent<ObjectFollower>();
            var hpUi = hpUiObject.GetComponent<HealthPointsUi>();

            objectFollower.SetObjectToFollow(transform, false);
            hpUi.SetHpPercentage(100);
        }

        public void DealDamage(float damage)
        {
            currentHealthPoints = damage;
        }
    }
}
