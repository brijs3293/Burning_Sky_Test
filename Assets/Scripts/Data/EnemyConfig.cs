using UnityEngine;

namespace EA.BurningSky.Data
{
    [System.Serializable]
    public struct RewardData
    {
        public RewardType rewardType;
        public float value;
    }

    /// <summary>
    /// A Scriptable object for Enemy configuration
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 1)]
    public class EnemyConfig : PlayerConfig
    {
        public EnemyType enemyType;
        public Vector3 enemyScale;
        /// <summary>
        /// Fire start time delay after spawning
        /// </summary>
        public float fireStartDelay;
        /// <summary>
        /// All rewards that are given when enemy is killed
        /// </summary>
        public RewardData[] rewardsAfterKill;
    }
}
