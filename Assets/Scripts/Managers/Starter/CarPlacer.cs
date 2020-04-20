using UnityEngine;

namespace Assets.Scripts.Managers.Starter
{
    public class CarPlacer : MonoBehaviour
    {
        [SerializeField] private Transform[] positions;

        public void PlaceCars(GameObject[] cars, bool[] playersInGame)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (playersInGame[i])
                {
                    var obj = Instantiate(cars[i], positions[i].position, positions[i].rotation);
                    obj.name = $"{cars[i].name} - {i}";
                }
            }
        }
    }
}
