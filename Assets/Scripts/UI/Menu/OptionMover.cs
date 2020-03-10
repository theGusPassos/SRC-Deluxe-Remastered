using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.UI.Menu
{
    [RequireComponent(typeof(RectTransform))]
    public class OptionMover : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Vector3 moveRate;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            var yMoveRate = rectTransform.rect.height / 2;
            moveRate = new Vector3(0, yMoveRate);
        }

        public void MoveDown()
        {
            transform.position += moveRate;
        }

        public void MoveUp()
        {
            transform.position -= moveRate;
        }
    }
}
