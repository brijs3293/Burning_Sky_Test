using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// Concrete  implementation of Zigzag enemy movement
    /// </summary>
    public class ZigZagEnemyMovement : StraightEnemyMovement
    {
        public ZigZagEnemyMovement(float speedMultiplier) : base(speedMultiplier)
        {
        }

        private float _targetVelocity;
        private float _time;
        private float _executionTime;
        private float sign = -1;

        /// <summary>
        /// A movement which changes direction at random number of seconds. Using sealed keyword to ensure it will not be overridden and has better performance in IL2CPP 
        /// </summary>
        public sealed override void MoveEnemy()
        {
            Vector3 bodyVelocity = enemyController.transform.forward * enemyController.enemyConfig.speed * speedMultiplier;
            _time += Time.fixedDeltaTime;
            if (_time < _executionTime)
            {
                bodyVelocity.x = sign * enemyController.enemyConfig.speed;
                enemyController.body.velocity = bodyVelocity;
                enemyController.body.position = new Vector3(
                    Mathf.Clamp(enemyController.body.position.x, -BoundaryDetector.screenBoundary.x + 0.1f, BoundaryDetector.screenBoundary.x - 0.1f),
                    0.0f,
                    enemyController.body.position.z
                );
            }
            else
            {
                sign = -Mathf.Sign(bodyVelocity.x);
                _executionTime = Random.Range(2f, 6f);
                _time = 0;
            }
        }
    }
}
