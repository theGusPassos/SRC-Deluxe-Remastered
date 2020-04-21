using Assets.Scripts.Configurations;
using Assets.Scripts.Controller;
using Assets.Scripts.Managers.Starter;
using Assets.Scripts.Systems.Observable;
using Assets.Scripts.UI.Battle;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public enum BattleEvent
    {
        ENDED
    }

    public class BattleController : IEventSender<BattleEvent>, IEventListener<CountDownEvent>
    {
        private CarPlacer carPlacer;
        private CarController[] controllers;

        [SerializeField] private CountDown startCountDown;
        [SerializeField] private CountDownUi startCountDownUi;

        [SerializeField] private CountDown battleCountDown;
        [SerializeField] private CountDownUi battleCountDownUi;

        private bool waitingStartCountDown;
        private bool WaitingStartCountDown
        {
            set
            {
                waitingStartCountDown = value;
                foreach (var controller in controllers)
                    controller.State.WaitingStartCountDown = waitingStartCountDown;
            }
            get => waitingStartCountDown;
        }

        private void Awake()
        {
            startCountDown.SubscribeToEvent(this, startCountDownUi);
            battleCountDown.SubscribeToEvent(this, battleCountDownUi);
        }

        private void GetCarPlacerForCurrentLevel()
        {
            carPlacer = GameObject.FindGameObjectWithTag("start place")
                .GetComponent<CarPlacer>();
        }

        private void SetControllers(GameObject[] cars)
        {
            if (controllers == null)
            {
                controllers = new CarController[cars.Length];

                for (int i = 0; i < cars.Length; i++)
                {
                    controllers[i] = cars[i].GetComponent<CarController>();
                }
            }
        }

        public void StartBattle(GameObject[] cars)
        {
            GetCarPlacerForCurrentLevel();
            carPlacer.PlaceCars(cars);

            SetControllers(cars);

            waitingStartCountDown = true;
            startCountDown.StartCountDown(BattleTimer.SecondsToStartRace);
        }

        public void SendEvent(CountDownEvent e)
        {
            if (e == CountDownEvent.ENDED)
            {
                if (WaitingStartCountDown)
                {
                    waitingStartCountDown = false;
                    battleCountDown.StartCountDown(BattleTimer.SecondsInBattle);
                }
                else
                {
                    SendEvent(BattleEvent.ENDED);
                }
            }
        }
    }
}
