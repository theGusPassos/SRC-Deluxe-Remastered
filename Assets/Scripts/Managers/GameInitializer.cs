using Assets.Scripts.Cars;
using Assets.Scripts.Managers.Starter;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private AvailableCars availableCars;
        [SerializeField] private CarPlacer carPlacer;
        [SerializeField] private InputHandlerCreator inputHandlerCreator;

        public void StartGame(bool[] playersInGame, int[] carsFromPlayers)
        {
            var carsPrefab = availableCars.GetCarsById(carsFromPlayers);
            var carsInGame = carPlacer.PlaceCars(carsPrefab, playersInGame);
            inputHandlerCreator.CreateInputHandlers(playersInGame, carsInGame);
        }
    }
}
