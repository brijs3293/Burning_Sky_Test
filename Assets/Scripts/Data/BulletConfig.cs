using UnityEngine;

namespace EA.BurningSky.Data
{
    /// <summary>
    /// A Scriptable object for Bullet configuration
    /// </summary>
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "ScriptableObjects/BulletConfig", order = 2)]
    public class BulletConfig : ScriptableObject
    {
        public BulletType bulletType;
        /// <summary>
        /// Damage of bullet
        /// </summary>
        public float power;
        public float speed;
        public PoolNames particleNameWhileHit;
    }
}
