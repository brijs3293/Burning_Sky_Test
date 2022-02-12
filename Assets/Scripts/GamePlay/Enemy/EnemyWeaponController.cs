using EA.BurningSky.Data;
using EA.BurningSky.ObjectPool;
using EA.BurningSky.Utility;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A class that manages fire from enemy as per configurations.
    /// </summary>
    public class EnemyWeaponController : MonoBehaviour
    {
        #region Public_Variables

        public Transform bulletSpawn;
        public EnemyConfig enemyConfig;

        #endregion

        #region Private_Variables

        private int _enemyLayer;

        #endregion

        #region Unity_Callbacks

        void OnEnable()
        {
            //Start regular interval fire
            InvokeRepeating(nameof(Fire), enemyConfig.fireStartDelay, enemyConfig.fireTime);
        }

        void Start()
        {
            _enemyLayer = LayerMask.NameToLayer(Constants.EnemyTag);
        }

        void OnDisable()
        {
            //Stop Fire
            CancelInvoke(nameof(Fire));
        }

        #endregion

        #region Private_Methods

        void Fire()
        {
            if (GamePlayManager.Instance.IsPlayingState)
            {
                var t = PoolManager.Spawn((enemyConfig.bulletName).ToEnum<PoolNames>());
                //Assign here enemy bullet enemy layer so it will only collide with Player as per physics collision matrix.
                t.gameObject.layer = _enemyLayer;
                t.position = bulletSpawn.position;
                t.forward = bulletSpawn.forward;
            }
        }

        #endregion

    }
}
