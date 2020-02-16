using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class RotateObject : MonoBehaviour
    {
        [SerializeField] private Vector3 rotation;

        private void Update()
        {
            transform.Rotate(rotation * Time.deltaTime);
        }
    }
}
