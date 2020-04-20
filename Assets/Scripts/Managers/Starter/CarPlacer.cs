using UnityEngine;

namespace Assets.Scripts.Managers.Starter
{
    public class CarPlacer : MonoBehaviour
    {
        [SerializeField] private Transform[] positions;

        public GameObject[] PlaceCars(GameObject[] cars, bool[] playersInGame)
        {
            var carsInGame = new GameObject[cars.Length];

            for (int i = 0; i < cars.Length; i++)
            {
                if (playersInGame[i])
                {
                    var carInGame = Instantiate(cars[i], positions[i].position, positions[i].rotation);
                    carInGame.name = $"{cars[i].name} - {i}";

                    carsInGame[i] = carInGame;
                }
            }

            return carsInGame;
        }
    }
}
