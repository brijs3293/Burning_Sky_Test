using System;
using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// An Implementation of IPowerEffector that will facilitate power application on player
    /// </summary>
    public class PowerInteraction : MonoBehaviour, IPowerEffector
    {
        #region Variables

        private Action _updateAction;
        //Dictionary cache to optimize serach as frequent power consumptions and no need to create objects everytime
        private Dictionary<PowerUpType, IPowerEffect> _powers = new Dictionary<PowerUpType, IPowerEffect>();

        #endregion

        #region Unity_Callbacks

        // Start is called before the first frame update
        void Start()
        {
            _powers.Add(PowerUpType.Shield, new ShieldPowerEffect(ref _updateAction));
            _powers.Add(PowerUpType.ShootingBoost, new ShootingBoostPowerEffect(ref _updateAction));
        }

        void Update()
        {
            _updateAction?.Invoke();
        }

        #endregion

        #region Public_Methods
        
        public void ApplyPower(PowerConfig powerConfig)
        {
            _powers[powerConfig.powerUpType].StartEffect(powerConfig);
        }

        public float GetApplicableValue(PowerUpType type, float value)
        {
            return _powers[type].GetApplicableValue(value);
        }
        #endregion
    }
}
