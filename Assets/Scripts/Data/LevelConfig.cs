using UnityEngine;

namespace EA.BurningSky.Data
{
    /// <summary>
    /// Configuration of single fleet. Every difficulty level has number of fleets.
    /// </summary>
    [System.Serializable]
    public struct FleetConfig
    {
        public EnemyType enemyType;
        public FleetType fleetType;
        public EnemyMovementType movementTypeType;
        public int numberOfEnemy;
        public float timeToLetPass;
    }

    /// <summary>
    /// A structure(custom datatype) for Level Progression 
    /// </summary>
    [System.Serializable]
    public struct LevelProgressionParameter
    {
        /// <summary>
        /// Parameter name for level progress
        /// </summary>
        public LevelProgressionParam param;
        /// <summary>
        /// Value required to complete condition of level completion
        /// </summary>
        public int value;
    }

    /// <summary>
    /// A databse to define levels and it's configurations
    /// </summary>
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig", order = 4)]
    public class LevelConfig : ScriptableObject
    {
        public DifficultyLevel difficultyLevel;
        /// <summary>
        /// Total number of fleets in this difficulty level. Using array here as expansion is not required runtime.
        /// </summary>
        public FleetConfig[] fleetConfigs;
        public float speedMultiplier;
        public int scoreMultiplier;
        /// <summary>
        /// All conditional data to be satisfied to complete particular level
        /// </summary>
        public LevelProgressionParameter[] levelProgressionParameters;
        /// <summary>
        /// Type of powers supported in this level
        /// </summary>
        public PowerUpType[] powersSupported;
    }
}

