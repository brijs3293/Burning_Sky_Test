using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        public BulletConfig bulletConfig;
        public Rigidbody body;
        void Start()
        {
            body.velocity = transform.up * bulletConfig.speed;
        }
    }
}
