namespace BurningSky.Gameplay
{
    /// <summary>
    /// An Interface which provides abstraction for different types of enemy movements. Strategy pattern
    /// </summary>
    public interface IEnemyMovement
    {
        void MoveEnemy();
        void SetController(EnemyController enemy);
    }
}
