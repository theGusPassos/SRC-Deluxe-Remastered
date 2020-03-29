using Assets.Scripts.Cars;
using UnityEngine;

namespace Assets.Scripts.UI.Menu.CarSelection
{
    [RequireComponent(typeof(CarSelectionUi))]
    public class CarSelectionMenu : MonoBehaviour
    {
        private CarSelectionUi carSelectionUi;
        [SerializeField] private AvailableCars availableCars;

        private bool[] playersPlaying = { true, false, false, false };
        private int[] selectedCarByPlayer = new int[4];

        private void SetDefaultCarForPlayers()
        {
            for (int i = 0; i < playersPlaying.Length; i++)
            {
                selectedCarByPlayer[i] = availableCars.GetDefaultCarForPlayer(i);
                carSelectionUi.SetFirstCarForPlayer(i, selectedCarByPlayer[i]);
            }
        }

        private void Start()
        {
            carSelectionUi = GetComponent<CarSelectionUi>();
            SetDefaultCarForPlayers();
        }

        private void Update()
        {
            GetPlayersEnteringGame();
        }

        private void GetPlayersEnteringGame()
        {
            for (int i = 2; i < playersPlaying.Length + 1; i++)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SetPlayerEnteredGame(i - 1);
                }
            }
        }

        private void SetPlayerEnteredGame(int player)
        {
            playersPlaying[player] = true;
            carSelectionUi.ActiveNewPlayer(player);
        }

        private void GetChangedCarInput()
        {
            for (int i = 0; i < playersPlaying.Length; i++)
            {
                string currentController = (i + 1).ToString();
            }
        }
    }
}
