using System;
using BurningSky.Data;
using BurningSky.ObjectPool;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A class which controls enemy. It has movement composition so it's 'Has a' relationship for movement using strategy pattern.
    /// </summary>
    public class EnemyController : MonoBehaviour
    {
        #region Public_Variables

        public EnemyConfig enemyConfig;
        public Rigidbody body;
        public IDamagable health;

        #endregion

        #region Private_Variables

        private IEnemyMovement _enemyMovement;

        #endregion

        #region Unity_Callbacks

        void Awake()
        {
            transform.localScale = enemyConfig.enemyScale;
        }

        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<IDamagable>();
            health.KillPlayer += KillPlayer;
            //SetMovementType(EnemyMovementType.Evasive);
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
            if (health != null)
            {
                health.KillPlayer -= KillPlayer;
            }
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
        /// <summary>
        /// Method that inits movement. This is injected from out side so it is not dependent on movement classes.
        /// </summary>
        public void SetMovement(IEnemyMovement movement)
        {
            _enemyMovement = movement;
            movement.SetController(this);
        }

        #endregion
    }
}
