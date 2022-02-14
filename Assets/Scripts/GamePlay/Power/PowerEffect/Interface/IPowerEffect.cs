using System.Collections;
using System.Collections.Generic;
using BurningSky.Data;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// An interface that defines power application on player. Strategy pattern
    /// </summary>
    public interface IPowerEffect
    {
        void StartEffect(PowerConfig powerConfig);
        float GetApplicableValue(float value);
        void Update();
    }
}
