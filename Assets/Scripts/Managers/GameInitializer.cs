using Assets.Scripts.Cars;
using Assets.Scripts.Managers.Starter;
using Assets.Scripts.Systems.Observable;
using Assets.Scripts.UI.Battle;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameInitializer : MonoBehaviour, IEventListener<CountDownEvent>
    {
        [SerializeField] private AvailableCars availableCars;
        [SerializeField] private CarPlacer carPlacer;
        [SerializeField] private InputHandlerCreator inputHandlerCreator;
        [SerializeField] private CountDown countDown;
        [SerializeField] private CountDownUi countDownUi;

        private void Awake()
        {
            
        }

        public void StartGame(bool[] playersInGame, int[] carsFromPlayers)
        {
            var carsPrefab = availableCars.GetCarsById(carsFromPlayers);
            var carsInGame = carPlacer.PlaceCars(carsPrefab, playersInGame);
            inputHandlerCreator.CreateInputHandlers(playersInGame, carsInGame);

            countDown.SubscribeToEvent(this, countDownUi);
            countDown.StartCountDown();
        }

        public void SendEvent(CountDownEvent e)
        {
            if (e == CountDownEvent.ENDED)
            {
                Debug.Log("should start the game");
            }
        }
    }
}
