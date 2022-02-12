using System;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A concrete implementation of shield power
    /// </summary>
    public class ShieldPowerEffect : IPowerEffect
    {
        private float _totalTime;
        private float _multiplier = 1;
        private Action _updateAction;

        public ShieldPowerEffect(ref Action updateAction)
        {
            _updateAction = updateAction;
        }

        public virtual void StartEffect(PowerConfig powerConfig)
        {
            //Cache data when power collided. here time is added so if same powers taken twice than it will last 2x time
            _totalTime += powerConfig.time;
            _multiplier = powerConfig.value;
            _updateAction += Update;
        }

        public virtual float GetApplicableValue(float value)
        {
            //Multiply when asked applicable data
            return value * _multiplier;
        }

        public void Update()
        {
            _totalTime -= Time.deltaTime;
            if (_totalTime <= 0)
            {
                //Stop power effect when time 0
                _totalTime = 0;
                _multiplier = 1;
                _updateAction -= Update;
            }
        }
    }
}
