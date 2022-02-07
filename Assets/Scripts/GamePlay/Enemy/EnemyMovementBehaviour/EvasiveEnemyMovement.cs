using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class EvasiveEnemyMovement : StraightEnemyMovement
    {
        public EvasiveEnemyMovement(EnemyController enemyController, float speedMultplier) : base(enemyController, speedMultplier)
        {
        }

        public sealed override void MoveEnemy()
        {

        }
    }
}
