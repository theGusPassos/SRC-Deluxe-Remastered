using Assets.Scripts.Controller;
using UnityEngine;

namespace Assets.Scripts.Managers.Starter
{
    public class InputHandlerCreator : MonoBehaviour
    {
        [SerializeField] private GameObject inputHandlerPrefab;

        public void CreateInputHandlers(GameObject[] carsInGame)
        {
            for (int i = 0; i < carsInGame.Length; i++)
            {
                GameObject inputHandler = Instantiate(inputHandlerPrefab);
                inputHandler.GetComponent<InputHandler>().CarController
                    = carsInGame[i].GetComponent<CarController>();
            }
        }
    }
}
