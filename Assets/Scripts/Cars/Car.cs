using Assets.Scripts.Cars.Effects;
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

        [SerializeField] private float timeToConsiderDrift;
        private float timeInDriftSetup = 0;

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

        public void ActivateDriftEffect(WheelInfo wheel)
        {
            wheel.wheelCollider.GetGroundHit(out WheelHit hit);

            var isEmitting = wheel.driftParticle.isEmitting;
            var isInDrift = Mathf.Abs(hit.sidewaysSlip) > carData.frictionToShowDriftEffect;

            if (!isEmitting && isInDrift)
            {
                timeInDriftSetup += Time.deltaTime;

                if (timeInDriftSetup > timeToConsiderDrift)
                {
                    Debug.Log("started drift");
                    wheel.driftParticle.Play();
                    wheel.wheelTrailEffect.StartWheelEffect();
                }
            }
            else if (isEmitting && !isInDrift)
            {
                Debug.Log("stopped");
                timeInDriftSetup = 0;

                wheel.driftParticle.Stop();
                wheel.wheelTrailEffect.StopWheelEffect();
            }
        }
    }

    [System.Serializable]
    public struct WheelInfo
    {
        public WheelCollider wheelCollider;
        public GameObject wheelModel;
        public ParticleSystem driftParticle;
        public WheelTrailEffect wheelTrailEffect;
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
        public float frictionToShowDriftEffect;
    }
}
