using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class ObjectFollower : MonoBehaviour
    {
        private Transform toFollow;

        public void SetObjectToFollow(Transform toFollow) => this.toFollow = toFollow;
        public void StopFollowing() => this.toFollow = null;

        private void Update()
        {
            if (toFollow != null)
            {
                transform.position = toFollow.position;
            }
        }
    }
}
