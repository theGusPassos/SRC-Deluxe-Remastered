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
        private Color originalColor;

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            fadeColor = new Color(0, 0, 0, fadeSpeed);
            originalColor = textMesh.color;
        }

        private void Update()
        {
            if (textMesh.color.a > 0)
                textMesh.color -= fadeColor * Time.deltaTime;
        }

        private void OnDisable()
        {
            textMesh.color = originalColor;
        }
    }
}
