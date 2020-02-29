using UnityEngine;

namespace Assets.Scripts.Battl.Health
{
    public class HealthPoints : MonoBehaviour
    {
        [SerializeField] private float maxHealthPoints;
        private float currentHealthPoints;

        private void Awake()
        {
            currentHealthPoints = maxHealthPoints;
        }

        public void DealDamage(float damage)
        {
            currentHealthPoints = damage;
        }
    }
}
