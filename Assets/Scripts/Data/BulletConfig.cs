using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Data
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "ScriptableObjects/BulletConfig", order = 2)]
    public class BulletConfig : ScriptableObject
    {
        public BulletType bulletType;
        public float power;
        public float speed;
        public PoolNames particleNameWhileHit;
    }
}
