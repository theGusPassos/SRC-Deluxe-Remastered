using UnityEngine;

namespace Assets.Scripts.UI.Menu.CarSelection
{
    public class CarSelectionUi : MonoBehaviour
    {
        private CarSelectedChanger[] carSelectedChangers;
        private PlayerActivator[] playerActivators;

        private void Awake()
        {
            carSelectedChangers = GetComponentsInChildren<CarSelectedChanger>();
            playerActivators = GetComponentsInChildren<PlayerActivator>();
        }

        public void SetFirstCarForPlayer(int playerId, int carId)
        {
            carSelectedChangers[playerId].SetFirstCar(carId);
        }

        public int GetSelectedCarAndSetReady(int playerId)
        {
            return carSelectedChangers[playerId].GetCarSelected();
        }

        public void ActiveNewPlayer(int playerId)
        {
            playerActivators[playerId - 1].ActivatePlayer();
        }

        public void GetNextCarForPlayer(int player)
        {
            carSelectedChangers[player].GoToNextCar();
        }

        public void GetPreviousCarForPlayer(int player)
        {
            carSelectedChangers[player].GoToPreviousCar();
        }
    }
}
