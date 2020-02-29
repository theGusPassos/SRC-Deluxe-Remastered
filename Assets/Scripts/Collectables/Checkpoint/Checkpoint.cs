using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Collectables.Checkpoint
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Checkpoint : MonoBehaviour
    {
        private CheckpointDeathAnimation deathAnimation;

        private void Start()
        {
            deathAnimation = GetComponent<CheckpointDeathAnimation>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            var checkpointCollectable = collision.GetComponent<CheckpointCollectable>();
            if (checkpointCollectable != null)
            {
                checkpointCollectable.AddCollectedCheckpoint();
                deathAnimation.PlayDeathAnimation();
            }
        }
    }
}
