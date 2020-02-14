using UnityEngine;

namespace Assets.Scripts.Cars
{
    public class Car : MonoBehaviour
    {
        [Tooltip("front left, front right, back left, back right")]
        [SerializeField] private WheelCollider[] wheelColliders;

        [Tooltip("front left, front right, back left, back right")]
        [SerializeField] private GameObject[] wheelModels;

        [SerializeField] private float maxSteeringAngle;

        public WheelCollider[] WheenlColliders { get => wheelColliders; }
        public float MaxSteeringAngle { get => maxSteeringAngle; }

        public void UpdateWheelPose()
        {
            for (int i = 0; i < wheelColliders.Length; i++)
            {
                wheelColliders[i].GetWorldPose(out Vector3 position, out Quaternion quaternion);
                wheelModels[i].transform.position = position;
                wheelModels[i].transform.rotation = quaternion;
            }
        }
    }
}
