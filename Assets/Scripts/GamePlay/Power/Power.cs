using BurningSky.Data;
using BurningSky.ObjectPool;
using UnityEditor;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A class responsible for power object travelling and detecting player trigger.
    /// </summary>
    public class Power : MonoBehaviour
    {
        public PowerConfig powerConfig;

        public Rigidbody body;
        // Start is called before the first frame update
        void Start()
        {
            body.velocity = -Vector3.forward * 0.1f;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.PlayerTag))
            {
                other.GetComponent<IPowerEffector>().ApplyPower(powerConfig);
                PoolManager.Despawn(transform);
            }
        }
    }
}
