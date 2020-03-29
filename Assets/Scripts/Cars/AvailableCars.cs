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
    }
}
