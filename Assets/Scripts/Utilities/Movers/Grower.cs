using UnityEngine;

namespace Assets.Scripts.Utilities.Movers
{
    public class Grower : MonoBehaviour
    {
        [SerializeField] private Vector3 scaleGrowDirection;
        [SerializeField] private float growSpeed;
        private Vector3 originalScale;

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        private void OnDisable()
        {
            transform.localScale = originalScale;
        }

        private void Update()
        {
            transform.localScale += scaleGrowDirection * growSpeed * Time.deltaTime;
        }
    }
}
