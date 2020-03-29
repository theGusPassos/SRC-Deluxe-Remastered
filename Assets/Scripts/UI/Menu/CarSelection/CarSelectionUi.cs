using UnityEngine;

namespace Assets.Scripts.UI.Menu.CarSelection
{
    public class CarSelectionUi : MonoBehaviour
    {
        private CarSelectedChanger[] carSelectedChangers;

        private void Awake()
        {
            carSelectedChangers = GetComponentsInChildren<CarSelectedChanger>();
        }

        public void SetFirstCarForPlayer(int playerId, int carId)
        {
            carSelectedChangers[playerId].SetFirstCar(carId);
        }
    }
}
