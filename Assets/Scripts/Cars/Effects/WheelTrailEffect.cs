using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Cars.Effects
{
    public class WheelTrailEffect : MonoBehaviour
    {
        [SerializeField] private GameObject wheelTrailPrefab;
        private ObjectFollower currentWheelTrail;

        public void StartWheelEffect()
        {
            var wheelTrail = Instantiate(wheelTrailPrefab, transform.position, transform.rotation);
            currentWheelTrail = wheelTrail.GetComponent<ObjectFollower>();
            currentWheelTrail.SetObjectToFollow(gameObject.transform);
        }

        public void StopWheelEffect()
        {
            currentWheelTrail.StopFollowing();
        }
    }
}
