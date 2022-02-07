using System.Collections.Generic;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.ObjectPool
{
    /// <summary>
    /// A Class an object's pool that do not support multiple variants in single pool to avoid string operation (or one more data as variant identification). So to identify multiple varients we need unique identities.
    /// </summary>
    public class ObjectPool : MonoBehaviour
    {
        #region Public_Variables
        /// <summary>
        /// Unique Name of pool
        /// </summary>
        public PoolNames poolName;

        /// <summary>
        /// Group of objects to keep hierarchy clean
        /// </summary>
        public Transform group;

        /// <summary>
        /// Dictionary used to improve search operation while delete(Remove) operation
        /// </summary>
        public Dictionary<int, Transform> spawnedObjects;

        /// <summary>
        /// Queue to maintain despawned objects in FIFO
        /// </summary>
        public Queue<Transform> deSpawnedObjects;

        /// <summary>
        /// Variable that contains prefab
        /// </summary>
        public GameObject objectToPool;

        /// <summary>
        /// Amount of objects to prepool
        /// </summary>
        public int amountToPool;
        #endregion

        #region Unity_Callbacks

        void Awake()
        {
            if (group == null)
            {
                group = transform;
            }
        }

        void Start()
        {
            spawnedObjects = new Dictionary<int, Transform>();
            deSpawnedObjects = new Queue<Transform>();

            //Prepool Required Objects
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(objectToPool);
                obj.SetActive(false);
                obj.transform.SetParent(group);
                deSpawnedObjects.Enqueue(obj.transform);
                PoolManager.MapObjectToPool(obj.transform, poolName);
            }
            PoolManager.RegisterPool(poolName, this);
        }

        void OnDestroy()
        {
            PoolManager.UnregisterPool(poolName);
        }

        #endregion

        #region Public_Methods

        public bool Spawn(out Transform t)
        {
            return GetTransformFromPool(out t);
        }

        public void Despawn(Transform despawn)
        {
            if (spawnedObjects.Remove(despawn.GetHashCode()))
            {
                despawn.gameObject.SetActive(false);
                deSpawnedObjects.Enqueue(despawn);
            }
        }

        #endregion

        #region Private_Methods

        private bool GetTransformFromPool(out Transform t)
        {
            if (deSpawnedObjects.Count > 0)
            {
                t = deSpawnedObjects.Dequeue();
                t.gameObject.SetActive(true);
            }
            else
            {
                t = Instantiate(objectToPool).transform;
                t.gameObject.SetActive(true);
                t.SetParent(group);
                spawnedObjects.Add(t.GetHashCode(), t);
                return true;
            }
            spawnedObjects.Add(t.GetHashCode(), t);
            return false;
        }

        #endregion
    }
}
