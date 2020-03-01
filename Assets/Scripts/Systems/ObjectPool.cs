using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class ObjectPool<Component> where Component : Object
    {
        private readonly int poolSize;
        private readonly GameObject prefab;

        private GameObject[] objectsInPool;
        private Component[] objectsComponents;

        public ObjectPool(int poolSize, GameObject prefab)
        {
            this.poolSize = poolSize;
            this.prefab = prefab;

            objectsInPool = new GameObject[poolSize];
            objectsComponents = new Component[poolSize];
        }

        public Component PlaceObject(Vector3 position, Transform parent = null)
        {
            for (int i = 0; i < poolSize; i++)
            {
                if (objectsInPool[i] == null)
                {
                    objectsInPool[i] = Object.Instantiate(prefab, position, Quaternion.identity, parent);
                    objectsComponents[i] = objectsInPool[i].GetComponent<Component>();
                    return objectsComponents[i];
                }
                else if (!objectsInPool[i].activeSelf)
                {
                    objectsInPool[i].transform.position = position;
                    objectsInPool[i].SetActive(true);
                    return objectsComponents[i];
                }
            }

            throw new System.Exception("No object available in pool " + prefab.name);
        }
    }
}
