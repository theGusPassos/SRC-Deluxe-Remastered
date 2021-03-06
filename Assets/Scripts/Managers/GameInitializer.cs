﻿using Assets.Scripts.BattleLevels;
using Assets.Scripts.Cars;
using Assets.Scripts.Managers.Starter;
using Assets.Scripts.Systems.Observable;
using Assets.Scripts.UI.Menu;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    [RequireComponent(typeof(InputHandlerCreator))]
    [RequireComponent(typeof(BattleController))]
    public class GameInitializer : MonoBehaviour, IEventListener<BattleEvent>
    {
        [SerializeField] private AvailableCars availableCars;
        [SerializeField] private BattleLevelCollection battleLevelCollection;
        [SerializeField] private MenuManager battleEndOptions;
        private InputHandlerCreator inputHandlerCreator;
        private BattleController battleController;

        private GameObject[] carsInstantiated;

        private void Awake()
        {
            inputHandlerCreator = GetComponent<InputHandlerCreator>();
            battleController = GetComponent<BattleController>();

            battleController.SubscribeToEvent(this);
        }

        private void Start()
        {
           // StartGame(0);   
        }

        public void StartGame(params int[] carsFromPlayers)
        {
            var carsPrefab = availableCars.GetCarsById(carsFromPlayers);
            carsInstantiated = InstantiateCars(carsPrefab);
            inputHandlerCreator.CreateInputHandlers(carsInstantiated);

            StartBattle();
        }

        private void StartBattle()
        {
            battleController.StartBattle(carsInstantiated);
        }

        private GameObject[] InstantiateCars(GameObject[] carsPrefabs)
        {
            var carsInstantiated = new GameObject[carsPrefabs.Length];

            for (int i = 0; i < carsPrefabs.Length; i++)
                carsInstantiated[i] = Instantiate(carsPrefabs[i]);

            return carsInstantiated;
        }

        public void SendEvent(BattleEvent e)
        {
            if (e == BattleEvent.ENDED)
            {
                HandleBattleEnd();
            }
        }

        private void HandleBattleEnd()
        {
            battleLevelCollection.GoToNextLevel();
            if (battleLevelCollection.IsInLastLevel())
            {
            }
            else
            {
                battleEndOptions.gameObject.SetActive(true);
            }
        }
    }
}
