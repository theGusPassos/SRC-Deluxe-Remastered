using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Managers.Starter
{
    public class CarPlacer : MonoBehaviour
    {
        [SerializeField] private Transform[] transforms;

        public void PlaceCars(GameObject[] cars)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].transform.position = transforms[i].position;
                cars[i].transform.rotation = transforms[i].rotation;
                cars[i].name += $" - {i}";
            }
        }
    }
}
