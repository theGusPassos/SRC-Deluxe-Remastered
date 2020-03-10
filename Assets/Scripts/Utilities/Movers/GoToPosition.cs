using UnityEngine;

namespace Assets.Scripts.Utilities.Movers
{
    public class GoToPosition : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 positionToGo;
        private bool isSet = false;

        public void SetPositionToGo(Vector3 positionToGo)
        {
            this.isSet = true;
            this.positionToGo = positionToGo;
        }

        private void Update()
        {
            if (isSet && transform.position != positionToGo)
                transform.position = Vector3.Lerp(transform.position, positionToGo, speed * Time.deltaTime);
        }
    }
}
