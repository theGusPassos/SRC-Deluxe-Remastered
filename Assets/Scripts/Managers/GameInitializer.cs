using Assets.Scripts.Cars;
using Assets.Scripts.Managers.Starter;
using Assets.Scripts.Systems.Observable;
using Assets.Scripts.UI.Battle;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    [RequireComponent(typeof(InputHandlerCreator))]
    [RequireComponent(typeof(BattleController))]
    public class GameInitializer : MonoBehaviour, IEventListener<BattleEvent>
    {
        [SerializeField] private AvailableCars availableCars;
        [SerializeField] private CarPlacer carPlacer;
        [SerializeField] private CountDownUi countDownUi;
        private InputHandlerCreator inputHandlerCreator;
        private BattleController battleController;

        private GameObject[] carsInstantiated;

        private void Awake()
        {
            inputHandlerCreator = GetComponent<InputHandlerCreator>();
            battleController = GetComponent<BattleController>();

            battleController.SubscribeToEvent(this);
        }

        public void StartGame(int[] carsFromPlayers)
        {
            var carsPrefab = availableCars.GetCarsById(carsFromPlayers);
            carsInstantiated = InstantiateCars(carsPrefab);
            inputHandlerCreator.CreateInputHandlers(carsInstantiated);

            StartBattle();
        }

        private void StartBattle()
        {
            battleController.StartBattle(carsInstantiated);
        }

        private GameObject[] InstantiateCars(GameObject[] carsPrefabs)
        {
            var carsInstantiated = new GameObject[carsPrefabs.Length];

            for (int i = 0; i < carsPrefabs.Length; i++)
                carsInstantiated[i] = Instantiate(carsPrefabs[i]);

            return carsInstantiated;
        }

        public void SendEvent(BattleEvent e)
        {
            if (e == BattleEvent.ENDED)
            {
                Debug.LogError("this battle has ended");
            }
        }
    }
}
