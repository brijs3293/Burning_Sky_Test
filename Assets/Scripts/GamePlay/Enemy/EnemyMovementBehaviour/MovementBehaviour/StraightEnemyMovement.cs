namespace BurningSky.Gameplay
{
    /// <summary>
    /// Concrete  implementation of Straight enemy movement
    /// </summary>
    public class StraightEnemyMovement : IEnemyMovement
    {
        public EnemyController enemyController;
        public float speedMultiplier;
        public StraightEnemyMovement(float speedMultiplier)
        {
            this.speedMultiplier = speedMultiplier;
        }

        public virtual void MoveEnemy()
        {
            enemyController.body.velocity = enemyController.transform.forward * enemyController.enemyConfig.speed * speedMultiplier;
        }

        public void SetController(EnemyController enemy)
        {
            this.enemyController = enemy;
        }


    }
}
