using Assets.Scripts.Configurations;
using Assets.Scripts.Systems.Observable;
using UnityEngine;

namespace Assets.Scripts.Managers.Starter
{
    public class CountDown : IEventSender<CountDownEvent>
    {
        private int countDown;

        private bool startedCounting;
        private int currentSecond;
        private float currentTime;

        public void StartCountDown(int countDown)
        {
            this.countDown = countDown;

            startedCounting = true;
            currentTime = currentSecond = 0;
            SendEvent(CountDownEvent.STARTED);
        }

        private void Update()
        {
            if (startedCounting)
            {
                currentTime += Time.deltaTime;

                if (currentTime > currentSecond + 1)
                {
                    currentSecond++;
                    SendEvent(CountDownEvent.SECOND_PASSED);
                }

                if (currentTime > countDown)
                {
                    startedCounting = false;
                    SendEvent(CountDownEvent.ENDED);
                }
            }
        }
    }

    public enum CountDownEvent
    {
        STARTED,
        ENDED,
        SECOND_PASSED
    }
}
