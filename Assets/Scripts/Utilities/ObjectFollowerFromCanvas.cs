using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class ObjectFollowerFromCanvas : MonoBehaviour
    {
        private Transform toFollow;
        private Vector3 distanceFromTarget;

        public void SetDistanceFromTarget(Vector3 distanceFromTarget) => this.distanceFromTarget = distanceFromTarget;
        public void SetObjectToFollow(Transform toFollow) => this.toFollow = toFollow;

        private void Update()
        {
            if (toFollow != null)
            {
                var toFollowInScreenPos = Camera.main.WorldToScreenPoint(toFollow.position);
                transform.position = toFollowInScreenPos + distanceFromTarget;
            }
        }
    }
}
