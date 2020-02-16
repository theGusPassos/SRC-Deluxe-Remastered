using UnityEngine;

namespace Assets.Scripts.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    public class Car : MonoBehaviour
    {
        private Rigidbody carRigidbody;
        [SerializeField] private Transform centerOfMass;
        [SerializeField] private WheelInfo[] wheels;
        [SerializeField] private CarTunningData carData;

        public WheelInfo[] Wheels { get => wheels; }
        public float MaxSteeringAngle { get => carData.maxSteeringAngle; }
        public float MotorForce { get => carData.motorForce; }
        public float BreakForce { get => carData.breakForce; }
        public float FrictionInDrift { get => carData.frictionInDrift; }

        private void Awake()
        {
            carRigidbody = GetComponent<Rigidbody>();
            carRigidbody.centerOfMass = centerOfMass.localPosition;
        }

        private void FixedUpdate()
        {
        }

        public void UpdateWheelPose(WheelInfo wheelToUpdate)
        {
            wheelToUpdate.wheelCollider.GetWorldPose(out Vector3 position, out Quaternion quaternion);
            wheelToUpdate.wheelModel.transform.position = position;
            wheelToUpdate.wheelModel.transform.rotation = quaternion;
        }
    }

    [System.Serializable]
    public struct WheelInfo
    {
        public WheelCollider wheelCollider;
        public GameObject wheelModel;
        public bool hasTorque;
        public bool hasSteering;
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
