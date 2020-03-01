using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class ObjectFollower : MonoBehaviour
    {
        private Transform toFollow;
        private bool followOnZ;

        public void SetObjectToFollow(Transform toFollow, bool followOnZ = true) 
        { 
            this.toFollow = toFollow;
            this.followOnZ = followOnZ;
        }

        public void StopFollowing() => this.toFollow = null;

        private void Update()
        {
            if (toFollow != null)
            {
                var toFollowPosition = toFollow.position;
                if (!followOnZ) toFollowPosition.z = transform.position.z;

                transform.position = toFollow.position;
            }
        }
    }
}
