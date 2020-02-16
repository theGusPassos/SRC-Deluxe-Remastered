using UnityEngine;

namespace Assets.Scripts.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    public class Car : MonoBehaviour
    {
        private Rigidbody carRigidbody;
        [SerializeField] private Transform centerOfMass;

        [Tooltip("front left, front right, back left, back right")]
        [SerializeField] private WheelCollider[] wheelColliders;
        [SerializeField] private int[] indexOfWheelsWithTorque;
        [Tooltip("front left, front right, back left, back right")]
        [SerializeField] private GameObject[] wheelModels;
        [SerializeField] private CarTunningData carData;

        public WheelCollider[] WheelsColliders { get => wheelColliders; }
        public WheelCollider[] WheelsWithTorque { get; private set; }
        public float MaxSteeringAngle { get => carData.maxSteeringAngle; }
        public float MotorForce { get => carData.motorForce; }
        public float BreakForce { get => carData.breakForce; }
        public float FrictionInDrift { get => carData.frictionInDrift; }

        private void Awake()
        {
            carRigidbody = GetComponent<Rigidbody>();
            carRigidbody.centerOfMass = centerOfMass.localPosition;

            SetWheelsWithTorque();
        }

        private void SetWheelsWithTorque()
        {
            WheelsWithTorque = new WheelCollider[indexOfWheelsWithTorque.Length];
            for (int i = 0; i < WheelsWithTorque.Length; i++)
            {
                int wheel = indexOfWheelsWithTorque[i];
                WheelsWithTorque[i] = wheelColliders[wheel];
            }
        }

        private void FixedUpdate()
        {
        }

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

    [System.Serializable]
    public struct CarTunningData
    {
        public float maxSteeringAngle;
        public float motorForce;
        public float breakForce;
        public float frictionInDrift;
    }
}
