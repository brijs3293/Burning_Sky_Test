using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Data
{
    [System.Serializable]
    public struct RewardData
    {
        public RewardType rewardType;
        public float value;
    }

    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 1)]
    public class EnemyConfig : PlayerConfig
    {
        public EnemyType enemyType;
        public float fireStartDelay;
        public RewardData[] rewardsAfterKill;
    }
}
