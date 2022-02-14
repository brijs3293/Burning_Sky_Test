using UnityEngine;

namespace BurningSky.Data
{
    /// <summary>
    /// A Scriptable object for Player configuration
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public float speed;
        public float fireTime;
        public float maxHealth;
        public BulletType bulletName;
        public PoolNames particleWhileBlast;
    }
}
