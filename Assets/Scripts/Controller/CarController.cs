using Assets.Scripts.Cars;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    [RequireComponent(typeof(Car))]
    public class CarController : MonoBehaviour
    {
        private Car car;
        private WheelFrictionCurve originalFriction;
        private WheelFrictionCurve frictionInHandBrake;

        private void Awake()
        {
            car = GetComponent<Car>();
        }

        private void Start()
        {
            originalFriction = car.Wheels[0].wheelCollider.sidewaysFriction;

            frictionInHandBrake = originalFriction;
            frictionInHandBrake.extremumValue = car.FrictionInDrift;
        }

        public void MoveCar(float steering, float acceleration, float brakeForce)
        {
            foreach (var wheel in car.Wheels)
            {
                if (wheel.hasSteering) 
                    wheel.wheelCollider.steerAngle = steering * car.MaxSteeringAngle;

                if (wheel.hasTorque)
                    wheel.wheelCollider.motorTorque = acceleration * car.MotorForce;

                if (brakeForce > 0 && wheel.hasTorque)
                    wheel.wheelCollider.motorTorque = -brakeForce * car.BreakForce;

                if (wheel.driftParticle != null)
                    car.ActivateDriftEffect(wheel);

                car.UpdateWheelPose(wheel);
            }
        }

        public void HandBreak(float steering)
        {
            foreach (var wheel in car.Wheels)
            {
                if (steering != 0)
                {
                    wheel.wheelCollider.sidewaysFriction = frictionInHandBrake;
                }
                else
                {
                    wheel.wheelCollider.brakeTorque = car.BreakForce;
                }
            }
        }

        public void ReleaseHandBreak()
        {
            foreach (var wheel in car.Wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
                wheel.wheelCollider.sidewaysFriction = originalFriction;
            }
        }
    }
}
