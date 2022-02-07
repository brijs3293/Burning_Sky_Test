using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.ObjectPool;
using UnityEngine;

namespace EA.BurningSky.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public float speed;
        public float fireTime;
        public float maxHealth;
        public PoolNames bulletName;
        public PoolNames particleWhileBlast;
    }
}
