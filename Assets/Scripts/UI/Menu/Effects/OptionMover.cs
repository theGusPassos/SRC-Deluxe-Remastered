using UnityEngine;

namespace Assets.Scripts.UI.Menu.Effects
{
    [RequireComponent(typeof(RectTransform))]
    public class OptionMover : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Vector3 moveRate;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            var yMoveRate = rectTransform.rect.height;
            moveRate = new Vector3(0, yMoveRate);
        }

        public void MoveDown()
        {
            transform.localPosition -= moveRate;
        }

        public void MoveUp()
        {
            transform.localPosition += moveRate;
        }
    }
}
