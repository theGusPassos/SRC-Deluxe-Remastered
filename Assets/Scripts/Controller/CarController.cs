using Assets.Scripts.Cars;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Car car;
        private WheelFrictionCurve originalFriction;
        private WheelFrictionCurve frictionInHandBrake;

        private void Awake()
        {
            originalFriction = car.WheelsWithTorque[0].sidewaysFriction;

            frictionInHandBrake = originalFriction;
            frictionInHandBrake.extremumValue = car.FrictionInDrift;
        }

        public void Steer(float steering)
        {
            car.WheelsColliders[0].steerAngle = steering * car.MaxSteeringAngle;
            car.WheelsColliders[1].steerAngle = steering * car.MaxSteeringAngle;

            car.UpdateWheelPose();
        }

        public void Accelerate(float acceleration)
        {
            foreach (var wheel in car.WheelsWithTorque)
            {
                wheel.motorTorque = acceleration * car.MotorForce;
            }
        }

        public void Break(float breakForce)
        {
            foreach (var wheel in car.WheelsWithTorque)
            {
                wheel.motorTorque = -breakForce * car.MotorForce;
            }
        }

        public void HandBreak(float steering)
        {
            foreach (var wheel in car.WheelsColliders)
            {
                if (steering != 0)
                {
                    wheel.sidewaysFriction = frictionInHandBrake;
                }
                else
                {
                    wheel.brakeTorque = car.BreakForce;
                }
            }
        }

        public void ReleaseHandBreak()
        {
            foreach (var wheel in car.WheelsColliders)
            {
                wheel.brakeTorque = 0;
                wheel.sidewaysFriction = originalFriction;
            }
        }
    }
}
