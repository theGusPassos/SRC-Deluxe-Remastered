﻿using Assets.Scripts.Cars;
using Assets.Scripts.Systems;
using UnityEngine;

namespace Assets.Scripts.Specials.Drift
{
    [RequireComponent(typeof(Car))]
    public class DriftCounter : MonoBehaviour, IEventListener<DriftEvent>
    {
        private IEventSender<DriftEvent> driftEvent;
        [SerializeField] private GameObject driftCounterUiPrefab;
        private DriftCounterUi driftCounterUi;

        private float maxDriftPointCount = 0;

        private bool isInDrift = false;
        private float timeInDrift;
        private float currentPointsInDrift;
        private int currentMultiplier = 1;

        private void Awake()
        {
            var driftEvent = GetComponent<Car>();
            driftEvent.SubscribeToEvent(this);
            SetupDriftCounterUi();
        }

        private void OnDestroy()
        {
            driftEvent.RemoveListener(this);
        }

        private void SetupDriftCounterUi()
        {
            var driftCounterObj = Instantiate(driftCounterUiPrefab, GameObject.Find("Canvas").transform);
            driftCounterUi = driftCounterObj.GetComponent<DriftCounterUi>();
            driftCounterUi.SetCarToFollow(transform);
        }

        private void Update()
        {
            if (isInDrift)
            {
                timeInDrift += Time.deltaTime;
                currentPointsInDrift = currentMultiplier 
                    * DriftConfiguration.instance.DriftPointsByTime 
                    * Time.deltaTime;

                driftCounterUi.SetCurrentPointsInDrift(currentPointsInDrift);

                if (TimeIsGreaterThanMultiplier(currentMultiplier, timeInDrift))
                {
                    currentMultiplier++;
                    driftCounterUi.SetMultiplier(currentMultiplier);
                }
            }
        }
        
        public bool TimeIsGreaterThanMultiplier(int multiplier, float time)
        {
            var driftMultiplierMinTime = DriftConfiguration.instance.DriftMultiplierMinTime;
            if (multiplier - 1 >=  driftMultiplierMinTime.Length)
                return false;

            return time > driftMultiplierMinTime[multiplier - 1];
        }

        public void SendEvent(DriftEvent e)
        {
            if (e == DriftEvent.STARTED_DRIFT)
            {
                currentPointsInDrift = 0;
                timeInDrift = 0;
                currentMultiplier = 1;
                isInDrift = true;
            }
            else if (e == DriftEvent.ENDED_DRIFT)
            {
                isInDrift = false;
                CalculateEndDrift();
            }
        }

        private void CalculateEndDrift()
        {
            maxDriftPointCount += currentPointsInDrift;
        }
    }

    public enum DriftEvent
    {
        STARTED_DRIFT,
        ENDED_DRIFT
    }
}