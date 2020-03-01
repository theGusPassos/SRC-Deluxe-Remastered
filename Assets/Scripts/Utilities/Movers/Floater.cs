using UnityEngine;

namespace Assets.Scripts.UI.Movers
{
    public class Floater : MonoBehaviour
    {
        [SerializeField] private Vector3 floatDirection;
        [SerializeField] private float floatSpeed;

        private void Update()
        {
            transform.position += floatDirection * floatSpeed * Time.deltaTime;
        }
    }
}
