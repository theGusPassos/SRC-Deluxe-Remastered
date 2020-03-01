using UnityEngine;

namespace Assets.Scripts.Utilities.Movers
{
    public class Grower : MonoBehaviour
    {
        [SerializeField] private Vector3 scaleGrowDirection;
        [SerializeField] private float growSpeed;

        private void Update()
        {
            transform.localScale += scaleGrowDirection * growSpeed * Time.deltaTime;
        }
    }
}
