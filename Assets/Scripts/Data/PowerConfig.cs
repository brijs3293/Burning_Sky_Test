using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Data
{
    [CreateAssetMenu(fileName = "PowerConfig", menuName = "ScriptableObjects/PowerConfig", order = 3)]
    public class PowerConfig : ScriptableObject
    {
        public PowerUpType powerUpType;
        public float time;
        public float value;
    }
}