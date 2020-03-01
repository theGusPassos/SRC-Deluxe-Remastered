using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class DisableAfterTime : MonoBehaviour
    {
        [SerializeField] private float timeToDisable;
        private float currentTimer = 0;

        private void OnEnable()
        {
            currentTimer = 0;
        }

        private void Update()
        {
            currentTimer += Time.deltaTime;
            if (currentTimer > timeToDisable)
                gameObject.SetActive(false);
        }
    }
}
