using UnityEngine;

namespace Assets.Scripts.UI.Menu.Effects
{
    [RequireComponent(typeof(RectTransform))]
    public class OptionMover : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Vector3 moveRate;
        private Vector3 firstPosition;

        private void Awake()
        {
            firstPosition = transform.localPosition;

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

        public void MoveToFirst()
        {
            transform.localPosition = firstPosition;
        }

        public void MoveToLast(int nOptions)
        {
            transform.localPosition = firstPosition - moveRate * (nOptions - 1);
        }
    }
}
