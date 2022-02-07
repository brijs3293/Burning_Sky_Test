using System;
using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class Health : MonoBehaviour, IDamagable
    {
        public PlayerConfig playerConfig;
        public Action killPlayer;
        private float _health;

        void Start()
        {
            DamageHandler.RegisterDamagable(transform.GetHashCode(), this);
        }

        void OnEnable()
        {
            _health = playerConfig.maxHealth;
        }

        void OnDestroy()
        {
            DamageHandler.UnRegisterDamagable(transform.GetHashCode());
        }

        public void Damage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                killPlayer?.Invoke();
            }
        }
    }
}
