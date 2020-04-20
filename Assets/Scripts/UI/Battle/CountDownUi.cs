using Assets.Scripts.Configurations;
using Assets.Scripts.Managers.Starter;
using Assets.Scripts.Systems.Observable;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Battle
{
    public class CountDownUi : MonoBehaviour, IEventListener<CountDownEvent>
    {
        private TextMeshProUGUI textMesh;
        private int seconds = 0;

        private void Awake()
        {
            textMesh = GetComponentInChildren<TextMeshProUGUI>();
            textMesh.enabled = false;
        }

        public void SendEvent(CountDownEvent e)
        {
            if (e == CountDownEvent.STARTED)
            {
                StartCountDown();
            }
            else if (e == CountDownEvent.SECOND_PASSED)
            {
                AddSecond();
            }
            else if (e == CountDownEvent.ENDED)
            {
                EndCountDown();
            }
        }

        private void StartCountDown()
        {
            textMesh.text = BattleTimer.SecondsToStartRace.ToString();
            textMesh.enabled = true;
        }

        private void AddSecond()
        {
            seconds++;
            textMesh.text = (BattleTimer.SecondsToStartRace - seconds).ToString();
        }

        private void EndCountDown()
        {
            textMesh.text = "GO!";
            StartCoroutine(DisableTextMesh());
        }

        private IEnumerator DisableTextMesh()
        {
            yield return new WaitForSeconds(1);
            textMesh.enabled = false;
        }
    }
}
