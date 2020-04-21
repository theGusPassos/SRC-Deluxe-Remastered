using Assets.Scripts.Configurations;
using Assets.Scripts.Controller;
using Assets.Scripts.Managers.Starter;
using Assets.Scripts.Systems.Observable;
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
        private CarControllerCollection controllerCollection;

        [SerializeField] private CountDown startCountDown;
        [SerializeField] private CountDown battleCountDown;

        private bool waitingStartCountDown;

        private void Awake()
        {
            startCountDown.SubscribeToEvent(this);
            battleCountDown.SubscribeToEvent(this);
        }

        private void GetCarPlacerForCurrentLevel()
        {
            carPlacer = GameObject.FindGameObjectWithTag("start place")
                .GetComponent<CarPlacer>();
        }

        public void StartBattle(GameObject[] cars)
        {
            GetCarPlacerForCurrentLevel();
            carPlacer.PlaceCars(cars);

            if (controllerCollection == null)
                controllerCollection = new CarControllerCollection(cars);

            waitingStartCountDown = true;
            controllerCollection.SetCanMove(false);

            startCountDown.StartCountDown(BattleTimer.SecondsToStartRace, "GO!");
        }

        public void SendEvent(CountDownEvent e)
        {
            if (e == CountDownEvent.ENDED)
            {
                if (waitingStartCountDown)
                {
                    waitingStartCountDown = false;
                    controllerCollection.SetCanMove(true);
                    battleCountDown.StartCountDown(BattleTimer.SecondsInBattle);
                }
                else
                {
                    controllerCollection.SetCanMove(false);
                    SendEvent(BattleEvent.ENDED);
                }
            }
        }
    }
}
