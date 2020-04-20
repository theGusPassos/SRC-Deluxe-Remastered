using Assets.Scripts.Controller;
using UnityEngine;

namespace Assets.Scripts.Managers.Starter
{
    public class InputHandlerCreator : MonoBehaviour
    {
        [SerializeField] private GameObject inputHandlerPrefab;

        public void CreateInputHandlers(bool[] playersInGame, GameObject[] carsInGame)
        {
            for (int i = 0; i < playersInGame.Length; i++)
            {
                if (!playersInGame[i]) return;

                GameObject inputHandler = Instantiate(inputHandlerPrefab);
                inputHandler.GetComponent<InputHandler>().CarController
                    = carsInGame[i].GetComponent<CarController>();
            }
        }
    }
}
