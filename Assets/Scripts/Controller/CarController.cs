using Assets.Scripts.Cars;
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

        public void MoveCar(float steering, float acceleration, float breaks)
        {
            wheelColliders[0].steerAngle = steering * car.MaxSteeringAngle;
            wheelColliders[1].steerAngle = steering * car.MaxSteeringAngle;

            car.UpdateWheelPose();
        }
    }
}
