using System;
using BurningSky.Data;
using BurningSky.Event;
using UnityEngine;
using EventType = BurningSky.Event.EventType;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A class attached to Player and enemy responsible for damage related functions. Inheriting IDamagable marks this object to get damage in game
    /// </summary>
    public class Health : MonoBehaviour, IDamagable
    {
        #region Public_Variables

        public PlayerConfig playerConfig;
        /// <summary>
        /// A delegate to fire when player or enemy dies
        /// </summary>
        public Action KillPlayer { get; set; }
        /// <summary>
        /// A Reference which provides correct data if shiled power is active.
        /// </summary>
        public IPowerEffector powerInteraction;

        #endregion

        #region Private_Variables
        private float _health;
        #endregion

        #region Unity_Callbacks
        void Start()
        {
            powerInteraction = GetComponent<IPowerEffector>();
            //Regisetering to damage handler so when bullet hits damage handler will have reference of this instance.
            DamageHandler.RegisterDamagable(transform.GetHashCode(), this);
            EventManager.RegisterMethod(EventType.GameStart, OnGameStart);
        }

        void OnEnable()
        {
            _health = playerConfig.maxHealth;
        }

        void OnDestroy()
        {
            DamageHandler.UnRegisterDamagable(transform.GetHashCode());
            EventManager.UnRegisterMethod(EventType.GameStart, OnGameStart);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.EnemyTag))
            {
                KillPlayer?.Invoke();
            }
        }

        #endregion

        #region Public_Methods

        public void Damage(float damage)
        {
            //Get correct data if shield is active
            _health -= powerInteraction.GetApplicableValue(PowerUpType.Shield, damage);
            if (gameObject.CompareTag(Constants.PlayerTag))
            {
                EventManager.InvokeAction(EventType.HealthUpdate, _health);
            }
            if (_health <= 0)
            {
                _health = 0;
                KillPlayer?.Invoke();
            }
        }

        public void OnGameStart()
        {
            Invoke(nameof(UpdateHealth), 0.1f);
        }
        #endregion

        #region Private_Methods
        void UpdateHealth()
        {
            if (gameObject.CompareTag(Constants.PlayerTag))
            {
                EventManager.InvokeAction(EventType.HealthUpdate, _health);
            }
        }
        #endregion

    }
}
