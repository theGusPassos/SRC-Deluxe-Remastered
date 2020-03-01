using Assets.Scripts.Cars.Effects;
using Assets.Scripts.Specials.Drift;
using Assets.Scripts.Systems;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    public class Car : MonoBehaviour, IEventSender<DriftEvent>
    {
        private Rigidbody carRigidbody;
        [SerializeField] private Transform centerOfMass;
        [SerializeField] private WheelInfo[] wheels;
        [SerializeField] private CarTunningData carData;

        [SerializeField] private float timeToConsiderDrift;
        private float timeInDriftSetup = 0;
        private int wheelsInDrift = 0;

        public WheelInfo[] Wheels { get => wheels; }
        public float MaxSteeringAngle { get => carData.maxSteeringAngle; }
        public float MotorForce { get => carData.motorForce; }
        public float BreakForce { get => carData.breakForce; }
        public float FrictionInDrift { get => carData.frictionInDrift; }

        private List<IEventListener<DriftEvent>> driftEventListeners
            = new List<IEventListener<DriftEvent>>();

        public void SubscribeToEvent(IEventListener<DriftEvent> listener)
        {
            driftEventListeners.Add(listener);
        }

        public void RemoveListener(IEventListener<DriftEvent> listener)
        {
            driftEventListeners.Remove(listener);
        }

        private void Awake()
        {
            carRigidbody = GetComponent<Rigidbody>();
            carRigidbody.centerOfMass = centerOfMass.localPosition;
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
                    if (wheelsInDrift == 0)
                    {
                        driftEventListeners.ForEach(a => a.SendEvent(DriftEvent.STARTED_DRIFT));
                    } 

                    wheelsInDrift++;
                    wheel.driftParticle.Play();
                    wheel.wheelTrailEffect.StartWheelEffect();
                }
            }
            else if (isEmitting && !isInDrift)
            {
                wheelsInDrift--;

                if (wheelsInDrift == 0)
                {
                    driftEventListeners.ForEach(a => a.SendEvent(DriftEvent.ENDED_DRIFT));
                }

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
