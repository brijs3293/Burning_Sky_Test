using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// Concrete  implementation of Evasive enemy movement
    /// </summary>
    public class EvasiveEnemyMovement : StraightEnemyMovement
    {
        private float sign = -1;
        public EvasiveEnemyMovement(float speedMultiplier) : base( speedMultiplier)
        {
            sign = Random.Range(0, 2) == 1 ? 1 : -1;
        }

        private float _time;

        /// <summary>
        /// A movement which changes direction every 2 seconds. Using sealed keyword to ensure it will not be overridden and has better performance in IL2CPP 
        /// </summary>
        public sealed override void MoveEnemy()
        {
            _time += Time.fixedDeltaTime;
            Vector3 bodyVelocity = enemyController.transform.forward * enemyController.enemyConfig.speed * speedMultiplier;
            bodyVelocity.x = sign * _time * enemyController.enemyConfig.speed * speedMultiplier;
            enemyController.body.velocity = bodyVelocity;

            enemyController.body.position = new Vector3(
                Mathf.Clamp(enemyController.body.position.x, -BoundaryDetector.screenBoundary.x + 0.1f, BoundaryDetector.screenBoundary.x - 0.1f),
                0.0f,
                enemyController.body.position.z
            );
            if (_time > 2)
            {
                sign = -sign;
                _time = 0;
            }
        }
    }
}
