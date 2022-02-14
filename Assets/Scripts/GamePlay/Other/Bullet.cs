using BurningSky.Data;
using BurningSky.ObjectPool;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A Bullet controller Class responsible for travelling and giving damage
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        public BulletConfig bulletConfig;
        public Rigidbody body;

        void FixedUpdate()
        {
            body.velocity = transform.forward * bulletConfig.speed;
        }

        public void OnTriggerEnter(Collider other)
        {
            //Give damage
            if (other.CompareTag(Constants.EnemyTag) || other.CompareTag(Constants.PlayerTag))
            {
                DamageHandler.Damage(other.transform.GetHashCode(), bulletConfig.power);
                PoolManager.Despawn(transform);
            }
        }
    }
}
