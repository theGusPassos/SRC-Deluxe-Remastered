using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Scripts.Collectables.Checkpoint
{
    public class CheckpointInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject checkpoint;
        [SerializeField] private GameObject floor;

        [SerializeField] private float timeToInstantiate;
        private float currentTimer = 0;

        [SerializeField] private float distanceFromWalls;

        private float maxX;
        private float minX;
        private float maxZ;
        private float minZ;

        private void Awake()
        {
            CalculateFloorBoundaries(); 
        }

        private void CalculateFloorBoundaries()
        {
            var mesh = floor.GetComponent<MeshRenderer>();
            maxX = mesh.bounds.max.x - distanceFromWalls;
            minX = mesh.bounds.min.x + distanceFromWalls;
            maxZ = mesh.bounds.max.z - distanceFromWalls;
            minZ = mesh.bounds.min.z + distanceFromWalls;
        }

        private void Update()
        {
            currentTimer += Time.deltaTime;

            if (currentTimer > timeToInstantiate)
            {
                currentTimer = 0;

                var xPos = Random.Range(minX, maxX);
                var zPos = Random.Range(minZ, maxZ);

                Instantiate(checkpoint, new Vector3(xPos, 0, zPos), checkpoint.transform.rotation);
            }
        }
    }
}
