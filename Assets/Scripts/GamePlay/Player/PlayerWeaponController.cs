using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using EA.BurningSky.ObjectPool;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class PlayerWeaponController : MonoBehaviour
    {
        #region Public_Variables

        public Transform bulletSpawn;
        public PlayerConfig playerConfig;

        #endregion

        #region Private_Variables

        private float _nextFire;

        #endregion

        #region Unity_Callbacks

        // Update is called once per frame
        void Update()
        {
            if (Time.time > _nextFire)
            {
                _nextFire = Time.time + playerConfig.fireTime;
                var t = PoolManager.Spawn(playerConfig.bulletName);
                t.position = bulletSpawn.position;
                t.rotation = bulletSpawn.rotation;
            }   
        }

        #endregion
    }
}
