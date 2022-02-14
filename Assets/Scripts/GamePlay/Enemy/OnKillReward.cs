using System;
using System.Collections;
using System.Collections.Generic;
using BurningSky.Data;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A script which gives reward when enemy is killed by player
    /// </summary>
    public class OnKillReward : MonoBehaviour
    {
        #region Variables
        public EnemyConfig enemyConfig;
        private IDamagable _health;
        #endregion

        #region Unity_Callbacks

        // Start is called before the first frame update
        void Start()
        {
            _health = GetComponent<IDamagable>();
            _health.KillPlayer += KillPlayer;
        }

        void OnDestroy()
        {
            if (_health != null)
            {
                _health.KillPlayer -= KillPlayer;
            }
        }

        #endregion

        #region Private_Methods
        /// <summary>
        /// Give reward when player kills enemy
        /// </summary>
        void KillPlayer()
        {
            RewardData[] rewards = enemyConfig.rewardsAfterKill;
            //Getting length before to avoid getting length every iteration  
            int length = rewards.Length;
            for (int i = 0; i < length; i++)
            {
                RewardData data = rewards[i];
                switch (data.rewardType)
                {
                    case RewardType.Score:
                        GameProgression.Instance.Score((int)data.value);
                        break;
                }
            }
        }
        #endregion
    }
}
