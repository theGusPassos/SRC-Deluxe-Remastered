using Assets.Scripts.Cars;
using Assets.Scripts.Controller;
using Assets.Scripts.Managers.Starter;
using Assets.Scripts.Systems.Observable;
using Assets.Scripts.UI.Battle;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    [RequireComponent(typeof(InputHandlerCreator))]
    [RequireComponent(typeof(CountDown))]
    public class GameInitializer : MonoBehaviour, IEventListener<CountDownEvent>
    {
        [SerializeField] private AvailableCars availableCars;
        [SerializeField] private CarPlacer carPlacer;
        [SerializeField] private CountDownUi countDownUi;
        private InputHandlerCreator inputHandlerCreator;
        private CountDown countDown;

        private CarController[] controllers;

        private void Awake()
        {
            inputHandlerCreator = GetComponent<InputHandlerCreator>();
            countDown = GetComponent<CountDown>();
        }

        public void StartGame(int[] carsFromPlayers)
        {
            var carsPrefab = availableCars.GetCarsById(carsFromPlayers);
            var carsInstantiated = InstantiateCars(carsPrefab);

            inputHandlerCreator.CreateInputHandlers(carsInGame);
            SetControllers(carsInGame);

            SetCarsCountDownState(true);
            countDown.SubscribeToEvent(this, countDownUi);
            countDown.StartCountDown();
        }

        private GameObject[] InstantiateCars(GameObject[] carsPrefabs)
        {
            var carsInstantiated = new GameObject[carsPrefabs.Length];

            for (int i = 0; i < carsPrefabs.Length; i++)
                carsInstantiated[i] = Instantiate(carsPrefabs[i]);

            return carsInstantiated;
        }

        private void SetControllers(GameObject[] carsInGame)
        {
            controllers = new CarController[carsInGame.Length];
            for (int i = 0; i < carsInGame.Length; i++)
                controllers[i] = carsInGame[i].GetComponent<CarController>();
        }

        public void SendEvent(CountDownEvent e)
        {
            if (e == CountDownEvent.ENDED)
            {
                SetCarsCountDownState(false);
            }
        }

        private void SetCarsCountDownState(bool waiting)
        {
            foreach (var controller in controllers)
            {
                controller.State.WaitingCountDown = waiting;
            }
        }
    }
}
