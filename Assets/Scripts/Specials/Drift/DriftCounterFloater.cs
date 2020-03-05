using Assets.Scripts.UI.TextUtilities;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Specials.Drift
{
    public class DriftCounterFloater : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI driftCounter;
        [SerializeField] private TextMeshProUGUI driftMultiplier;

        public void SetFloater(string driftCounter, string driftMultiplier)
        {
            this.driftCounter.text = driftCounter;
            this.driftMultiplier.text = driftMultiplier;
        }
    }
}
