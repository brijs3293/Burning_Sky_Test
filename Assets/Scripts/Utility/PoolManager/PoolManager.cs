using System;
using System.Collections.Generic;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.ObjectPool
{

    /// <summary>
    /// A Class that manages all Pools and is direct interface to User.
    /// </summary>
    public class PoolManager
    {
        /// <summary>
        /// All Pools use in game
        /// </summary>
        private static readonly Dictionary<PoolNames, ObjectPool> _pools = new Dictionary<PoolNames, ObjectPool>();

        /// <summary>
        /// Dictionary storing mapping of all spawned objects to its poolName which enables no Poolname needed while despawning which eventually remove requirement of object variants (of same type let say Bullet1, Bullet2) recognition.
        /// </summary>
        private static readonly Dictionary<int, PoolNames> _pooledObjectsToPoolName = new Dictionary<int, PoolNames>();

        /// <summary>
        /// Registers pool 
        /// </summary>
        /// <param name="poolName"></param>
        /// <param name="pool"></param>
        public static void RegisterPool(PoolNames poolName, ObjectPool pool)
        {
            if (!_pools.ContainsKey(poolName))
            {
                _pools.Add(poolName, pool);
            }
            else
            {
                throw new ArgumentException("Duplicate pool Registration. Please maintain single pool for a Name");
            }
        }

        /// <summary>
        /// Unregisters pool 
        /// </summary>
        /// <param name="poolName"></param>
        public static void UnregisterPool(PoolNames poolName)
        {
            if (_pools.ContainsKey(poolName))
            {
                _pools.Remove(poolName);
            }
        }

        /// <summary>
        /// Spawns Object from given pool
        /// </summary>
        /// <param name="poolName"></param>
        /// <returns></returns>
        public static Transform Spawn(PoolNames poolName)
        {
            if (_pools.TryGetValue(poolName, out var pool))
            {
                if (pool.Spawn(out var t))
                {
                    _pooledObjectsToPoolName.Add(t.GetHashCode(), poolName);
                }
                return t;
            }
            throw new ArgumentException("There is no pool Exists with given Name : " + poolName);
        }

        /// <summary>
        /// Despawns object to given pool 
        /// </summary>
        /// <param name="poolName"></param>
        /// <param name="obj"></param>
        public static void Despawn(PoolNames poolName, Transform obj)
        {
            if (_pools.TryGetValue(poolName, out var pool))
            {
                pool.Despawn(obj);
                return;
            }
            throw new ArgumentException("There is no pool Exists with given Name : " + poolName);
        }

        /// <summary>
        /// Despawn Given Object if pooled
        /// </summary>
        /// <param name="obj"></param>
        public static void Despawn(Transform obj)
        {
            if (_pooledObjectsToPoolName.TryGetValue(obj.GetHashCode(), out var poolName))
            {
                if (_pools.TryGetValue(poolName, out var pool))
                {
                    pool.Despawn(obj);
                    return;
                }
                throw new ArgumentException("There is no pool Exists with given Name : " + poolName);
            }
        }

        public static void MapObjectToPool(Transform t, PoolNames poolName)
        {
            _pooledObjectsToPoolName.Add(t.GetHashCode(), poolName);
        }
    }
}
