using System;
using EA.BurningSky.Data;
using EA.BurningSky.ObjectPool;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class EnemyController : MonoBehaviour
    {
        #region Public_Variables

        public EnemyConfig enemyConfig;
        public Rigidbody body;
        public Health health;

        #endregion

        #region Private_Variables

        private IEnemyMovement _enemyMovement;

        #endregion

        #region Unity_Callbacks

        // Start is called before the first frame update
        void Start()
        {
            health.killPlayer += KillPlayer;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.MoveEnemy();
            }
        }

        void OnDestroy()
        {
            health.killPlayer -= KillPlayer;
        }

        #endregion

        #region Private_Methods

        void KillPlayer()
        {
            PoolManager.Despawn(transform);
            //Create particle here
        }

        #endregion

        #region Public_Methods

        public void SetMovementType(EnemyMovementType movementTypeType, float speedMultiplier = 1)
        {
            switch (movementTypeType)
            {
                case EnemyMovementType.Straight:
                    _enemyMovement = new StraightEnemyMovement(this, speedMultiplier);
                    break;
                case EnemyMovementType.Zigzag:
                    _enemyMovement = new ZigZagEnemyMovement(this, speedMultiplier);
                    break;
                case EnemyMovementType.Evasive:
                    _enemyMovement = new EvasiveEnemyMovement(this, speedMultiplier);
                    break;

            }
        }


        #endregion
    }
}
