using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class StraightEnemyMovement : IEnemyMovement
    {
        public EnemyController enemyController;
        public float speedMultiplier;
        public StraightEnemyMovement(EnemyController enemyController, float speedMultplier)
        {
            this.enemyController = enemyController;
            this.speedMultiplier = speedMultplier;
        }

        public virtual void MoveEnemy()
        {
            enemyController.body.velocity = -enemyController.transform.forward * enemyController.enemyConfig.speed * speedMultiplier;
        }
    }
}
