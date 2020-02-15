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
        private WheelCollider[] wheelsWithTorque;

        [Tooltip("front left, front right, back left, back right")]
        [SerializeField] private GameObject[] wheelModels;

        [SerializeField] private CarTunningData carData;

        public WheelCollider[] WheelsColliders { get => wheelColliders; }
        public WheelCollider[] WheelsWithTorque { get => wheelsWithTorque; }
        public float MaxSteeringAngle { get => carData.maxSteeringAngle; }
        public float MotorForce { get => carData.motorForce; }
        public float BreakForce { get => carData.breakForce; }

        private void Awake()
        {
            carRigidbody = GetComponent<Rigidbody>();
            carRigidbody.centerOfMass = centerOfMass.localPosition;

            SetWheelsWithTorque();
        }

        private void SetWheelsWithTorque()
        {
            wheelsWithTorque = new WheelCollider[indexOfWheelsWithTorque.Length];
            for (int i = 0; i < wheelsWithTorque.Length; i++)
            {
                wheelsWithTorque[i] = wheelColliders[i];
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
    }
}
