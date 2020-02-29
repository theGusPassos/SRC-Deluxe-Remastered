using UnityEngine;

namespace Assets.Scripts.Collectables.Checkpoint
{
    public class CheckpointDeathAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject clock;
        [SerializeField] private float explosionSpeed;
        [SerializeField] private float timeToEnd;
        private bool playingAnimation = false;
        private float currentTimer;

        public void PlayDeathAnimation()
        {
            clock.SetActive(false);
            currentTimer = 0;
            playingAnimation = true;
        }

        private void Update()
        {
            if (playingAnimation)
            {
                currentTimer += Time.deltaTime;
                transform.localScale += Vector3.one * explosionSpeed * Time.deltaTime;

                if (currentTimer > timeToEnd)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
