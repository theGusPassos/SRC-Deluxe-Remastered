using Assets.Scripts.Cars;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menu.CarSelection
{
    public class CarSelectedChanger : MonoBehaviour
    {
        [SerializeField] private Image selectedCarImage;
        [SerializeField] private AvailableCars availableCars;
        [SerializeField] private TextMeshProUGUI infoText;
        private int currentCarSelected;

        public void SetFirstCar(int carId)
        {
            currentCarSelected = carId;
            selectedCarImage.sprite = availableCars.CarSelectionImages[carId]; 
        }

        public void GoToNextCar()
        {
            currentCarSelected++;
            if (currentCarSelected >= availableCars.CarSelectionImages.Length)
            {
                currentCarSelected = 0;
            }

            selectedCarImage.sprite = availableCars.CarSelectionImages[currentCarSelected];
        }

        public void GoToPreviousCar()
        {
            currentCarSelected--;
            if (currentCarSelected < 0)
            {
                currentCarSelected = availableCars.CarSelectionImages.Length - 1;
            }

            selectedCarImage.sprite = availableCars.CarSelectionImages[currentCarSelected];
        }
    
        public int GetCarSelected()
        {
            infoText.text = "READY";
            return currentCarSelected;
        }
    }
}
