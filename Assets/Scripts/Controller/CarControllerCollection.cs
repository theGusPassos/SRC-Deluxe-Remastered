using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CarControllerCollection
    {
        private readonly CarController[] controllers;

        public CarControllerCollection(GameObject[] cars)
        {
            controllers = new CarController[cars.Length];

            for (int i = 0; i < cars.Length; i++)
            {
                controllers[i] = cars[i].GetComponent<CarController>();
            }
        }

        public void SetWaitingStartCountDown(bool waiting)
        {
            foreach (var controller in controllers)
                controller.State.WaitingStartCountDown = waiting;
        }

        public void SetOnBattle(bool onBattle)
        {
            foreach (var controller in controllers)
                controller.State.IsInBattle = onBattle;
        }
    }
}
