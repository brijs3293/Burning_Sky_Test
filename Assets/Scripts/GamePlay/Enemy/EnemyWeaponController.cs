using EA.BurningSky.Data;
using EA.BurningSky.ObjectPool;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class EnemyWeaponController : MonoBehaviour
    {
        #region Public_Variables

        public Transform bulletSpawn;
        public EnemyConfig enemyConfig;

        #endregion

        #region Private_Variables
        #endregion

        #region Unity_Callbacks

        void Start()
        {
            InvokeRepeating(nameof(Fire), enemyConfig.fireStartDelay, enemyConfig.fireTime);
        }

        #endregion

        #region Private_Methods

        void Fire()
        {
            var t = PoolManager.Spawn(enemyConfig.bulletName);
            t.position = bulletSpawn.position;
            t.rotation = bulletSpawn.rotation;
        }

        #endregion

    }
}
