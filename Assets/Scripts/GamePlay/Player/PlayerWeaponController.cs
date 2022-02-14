using BurningSky.Data;
using BurningSky.ObjectPool;
using BurningSky.Utility;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A class which is responsible for player fire as per c onfiguration
    /// </summary>
    public class PlayerWeaponController : MonoBehaviour
    {
        #region Public_Variables

        public Transform bulletSpawn;
        public PlayerConfig playerConfig;
        public IPowerEffector powerInteraction;

        #endregion

        #region Private_Variables

        private float _nextFire;
        private int _playerLayer;
        #endregion

        #region Unity_Callbacks

        void Start()
        {
            powerInteraction = GetComponent<IPowerEffector>();
            _playerLayer = LayerMask.NameToLayer(Constants.PlayerTag);
        }

        // Update is called once per frame
        void Update()
        {
            if (GamePlayManager.Instance.IsPlayingState)
            {
                if (Time.time > _nextFire)
                {
                    int bulletsToFire = (int)powerInteraction.GetApplicableValue(PowerUpType.ShootingBoost, 1);
                    for (int i = 0; i < bulletsToFire; i++)
                    {
                        _nextFire = Time.time + playerConfig.fireTime;
                        var t = PoolManager.Spawn((playerConfig.bulletName).ToEnum<PoolNames>());
                        t.gameObject.layer = _playerLayer;
                        t.position = bulletSpawn.position;
                        t.forward = Quaternion.Euler(0, Random.Range(0, 3.5f) * (i > 0 ? 1 : 0), 0) *
                                    bulletSpawn.forward;
                    }
                }
            }
        }

        #endregion
    }
}
