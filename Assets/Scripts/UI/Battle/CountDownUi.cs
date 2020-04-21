using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Battle
{
    public class CountDownUi : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;
        private int secondsToCount;
        private int seconds = 0;

        private void Awake()
        {
            textMesh = GetComponentInChildren<TextMeshProUGUI>();
            textMesh.enabled = false;
        }

        public void StartCountDown(int secondsToCount)
        {
            this.secondsToCount = secondsToCount;
            textMesh.text = secondsToCount.ToString();
            textMesh.enabled = true;
        }

        public void AddSecond()
        {
            seconds++;
            textMesh.text = (secondsToCount - seconds).ToString();
        }

        public void EndCountDown(string textToShow = "")
        {
            textMesh.text = textToShow;
            StartCoroutine(DisableTextMesh());
        }

        private IEnumerator DisableTextMesh()
        {
            yield return new WaitForSeconds(1);
            textMesh.enabled = false;
        }
    }
}
