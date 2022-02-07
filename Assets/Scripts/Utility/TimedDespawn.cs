using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.ObjectPool;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class TimedDespawn : MonoBehaviour
    {
        public float time;

        private float _t;

        void OnEnable()
        {
            _t = 0;
        }

        // Update is called once per frame
        void Update()
        {
            _t += Time.deltaTime;
            if (_t > time)
            {
                PoolManager.Despawn(transform);
            }
        }
    }
}
