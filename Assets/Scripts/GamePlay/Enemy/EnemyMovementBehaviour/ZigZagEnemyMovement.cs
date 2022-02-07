using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class ZigZagEnemyMovement : StraightEnemyMovement
    {
        public ZigZagEnemyMovement(EnemyController enemyController, float speedMultplier) : base(enemyController, speedMultplier)
        {
        }

        public sealed override void MoveEnemy()
        {

        }
    }
}
