using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Utilities.Trail
{
    public class RemoveMaterialAlphaOverTime : MonoBehaviour
    {
        private TrailRenderer trailRenderer;
        [SerializeField] private float removeRate;
        [SerializeField] private float timeToStartRemoving;

        private Color originalColor;
        private Color colorRemoveRate;
        private float currentTimer = 0;

        private void Awake()
        {
            trailRenderer = GetComponent<TrailRenderer>();
            originalColor = trailRenderer.material.GetColor("_Color");
            colorRemoveRate = new Color(0, 0, 0, removeRate);
        }

        private void Update()
        {
            currentTimer += Time.deltaTime;

            if (currentTimer > timeToStartRemoving)
            {
                originalColor -= colorRemoveRate * Time.deltaTime;
                if (originalColor.a > 0)
                    trailRenderer.material.SetColor("_Color", originalColor);
                else
                    Destroy(gameObject);
            }
        }
    }
}
