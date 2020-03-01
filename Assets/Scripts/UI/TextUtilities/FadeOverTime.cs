using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.TextUtilities
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class FadeOverTime : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;
        [SerializeField] private float fadeSpeed;
        private Color fadeColor;

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            fadeColor = new Color(0, 0, 0, fadeSpeed);
        }

        private void Update()
        {
            textMesh.color -= fadeColor * Time.deltaTime;
        }
    }
}
