using Assets.Scripts.Cars;
using Assets.Scripts.Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI.Menu.CarSelection
{
    [RequireComponent(typeof(CarSelectionUi))]
    public class CarSelectionMenu : MonoBehaviour
    {
        private CarSelectionUi carSelectionUi;
        [SerializeField] private AvailableCars availableCars;
        [SerializeField] private GameInitializer gameInitializer;

        private bool[] playersPlaying = { true, false, false, false };
        private bool[] playersReady = { false, false, false, false };
        private int[] selectedCarByPlayer = new int[4];

        private bool started = false;

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
            if (started) return;
            GetPlayersEnteringGameInput();
            GetChangedCarInput();
            GetPlayerReadyInput();
        }

        private void GetPlayersEnteringGameInput()
        {
            for (int i = 1; i < playersPlaying.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !playersPlaying[i])
                {
                    playersPlaying[i] = true;
                    carSelectionUi.ActiveNewPlayer(i);
                }
            }
        }

        private void GetChangedCarInput()
        {
            for (int i = 0; i < playersPlaying.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) && playersPlaying[i])
                {
                    carSelectionUi.GetNextCarForPlayer(i);
                }
            }
        }

        private void GetPlayerReadyInput()
        {
            for (int i = 0; i < playersPlaying.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Return) && playersPlaying[i] && !playersReady[i])
                {
                    selectedCarByPlayer[i] = carSelectionUi.GetSelectedCarAndSetReady(i);
                    playersReady[i] = true;

                    TestGameStarted();
                }
            }
        }
    
        private void TestGameStarted()
        {
            int playerPlayingCount = playersPlaying.Where(a => a).Count();
            int playerReadyCount = playersReady.Where(a => a).Count();
            if (playerPlayingCount > 1 && playerPlayingCount == playerReadyCount)
            {
                var carsFromActivePlayers = GetCarsFromActivePlayers(playersPlaying, selectedCarByPlayer);

                gameInitializer.StartGame(carsFromActivePlayers);
                gameObject.SetActive(false);
            }
        }

        private int[] GetCarsFromActivePlayers(bool[] playersPlaying, int[] cars)
        {
            var carsPlaying = new List<int>();
            for (int i = 0; i < playersPlaying.Length; i++)
            {
                if (playersPlaying[i]) carsPlaying.Add(cars[i]);
            }

            return carsPlaying.ToArray();
        }
    }
}
