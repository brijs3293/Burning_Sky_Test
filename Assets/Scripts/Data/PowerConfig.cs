using UnityEngine;

namespace BurningSky.Data
{
    [CreateAssetMenu(fileName = "PowerConfig", menuName = "ScriptableObjects/PowerConfig", order = 3)]
    public class PowerConfig : ScriptableObject
    {
        public PowerUpType powerUpType;
        /// <summary>
        /// Total time this power will have effect
        /// </summary>
        public float time;
        /// <summary>
        /// The effect value. Let say if valu for shooting booster is 2 then 2 bullets will fire. Likewise every power implementation will consider this value according to it's own use
        /// </summary>
        public float value;
    }
}