using Assets.Scripts.Systems.Observable;
using Assets.Scripts.UI.Battle;
using UnityEngine;

namespace Assets.Scripts.Managers.Starter
{
    [RequireComponent(typeof(CountDownUi))]
    public class CountDown : IEventSender<CountDownEvent>
    {
        private CountDownUi countDownUi;

        private int countDown;
        private int currentSecond;
        private float currentTime;
        private bool startedCounting;
        private string textToShowOnEnd;

        private void Awake()
        {
            countDownUi = GetComponent<CountDownUi>();
        }

        public void StartCountDown(int countDown, string textToShowOnEnd = "")
        {
            this.countDown = countDown;
            this.textToShowOnEnd = textToShowOnEnd;

            currentTime = currentSecond = 0;

            startedCounting = true;
            countDownUi.StartCountDown(countDown);
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
                    countDownUi.AddSecond();
                }

                if (currentTime > countDown)
                {
                    startedCounting = false;
                    countDownUi.EndCountDown(textToShowOnEnd);
                    SendEvent(CountDownEvent.ENDED);
                }
            }
        }
    }

    public enum CountDownEvent
    {
        STARTED,
        ENDED
    }
}
