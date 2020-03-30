using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Cars
{
    public class AvailableCars : MonoBehaviour
    {
        [SerializeField] private GameObject[] availableCarsPrefabs;
        [SerializeField] private Sprite[] carSelectionImages;

        public int AvailableCarsCount { get => availableCarsPrefabs.Length; }
        public Sprite[] CarSelectionImages { get => carSelectionImages; }

        public int GetDefaultCarForPlayer(int player)
        {
            return 0;
        }

        public GameObject[] GetCarsById(int[] cars)
        {
            var carsToReturn = new GameObject[cars.Length];
            for (int i = 0; i < cars.Length; i++)
                if (cars[i] != -1)
                    carsToReturn[i] = availableCarsPrefabs[cars[i]];

            return carsToReturn;
        }
    }
}
