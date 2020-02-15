using Assets.Scripts.Cars;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Car car;
        private WheelCollider[] wheelColliders;

        private void Awake()
        {
            wheelColliders = car.WheenlColliders;
        }

        public void Steer(float steering)
        {
            wheelColliders[0].steerAngle = steering * car.MaxSteeringAngle;
            wheelColliders[1].steerAngle = steering * car.MaxSteeringAngle;

            car.UpdateWheelPose();
        }

        public void Accelerate(float acceleration)
        {
             foreach (var wheel in wheelColliders)
                wheel.motorTorque = acceleration * car.MotorForce;
            // wheelColliders[2].motorTorque = acceleration * car.MotorForce;
            // wheelColliders[3].motorTorque = acceleration * car.MotorForce;
        }

        public void Break(float breakForce)
        {
            foreach (var wheel in wheelColliders)
                wheel.brakeTorque = breakForce * car.BreakForce;
        }
    }
}
