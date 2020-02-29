using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CheckpointCollectable : MonoBehaviour
    {
        private int checkpointsCollected = 0;

        public void AddCollectedCheckpoint()
        {
            checkpointsCollected++;
        }
    }
}
