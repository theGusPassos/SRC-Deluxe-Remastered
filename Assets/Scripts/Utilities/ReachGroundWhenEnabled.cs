using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class ReachGroundWhenEnabled : MonoBehaviour
    {
        [SerializeField] private LayerMask floorLayerMask;
        [SerializeField] private float maxRayDistance;

        private void OnEnable()
        {
            var meshRenderer = GetComponent<MeshRenderer>();

            var ray = new Ray(transform.position, Vector3.down);
            var hit = Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: maxRayDistance, layerMask: floorLayerMask);
            if (hit)
            {
                var distanceFromGround = -hitInfo.distance + (meshRenderer.bounds.size.y / 2);
                transform.position += new Vector3(0, distanceFromGround);
            }
        }
    }
}
