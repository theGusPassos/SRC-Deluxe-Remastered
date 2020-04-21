using Assets.Scripts.Configurations;
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

        [SerializeField] private CountDown startCountDown;
        [SerializeField] private CountDownUi startCountDownUi;

        [SerializeField] private CountDown battleCountDown;
        [SerializeField] private CountDownUi battleCountDownUi;

        private bool awaitingStartCountDown;

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

        public void StartBattle(GameObject[] carPrefabs)
        {
            GetCarPlacerForCurrentLevel();
            carPlacer.PlaceCars(carPrefabs);

            awaitingStartCountDown = true;
            startCountDown.StartCountDown(BattleTimer.SecondsToStartRace);
        }

        public void SendEvent(CountDownEvent e)
        {
            if (e == CountDownEvent.ENDED)
            {
                if (awaitingStartCountDown)
                {
                    awaitingStartCountDown = false;
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
