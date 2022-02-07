using UnityEngine;

namespace EA.BurningSky.Data
{
    [System.Serializable]
    public struct FleetConfig
    {
        public EnemyType enemyType;
        public FleetType fleetType;
        public EnemyMovementType movementTypeType;
        public int numberOfEnemy;
    }

    [System.Serializable]
    public struct LevelProgressionParameter
    {
        public LevelProgressionParam param;
        public int value;
    }

    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig", order = 4)]
    public class LevelConfig : ScriptableObject
    {
        public FleetConfig[] fleetConfigs;
        public float speedMultiplier;
        public int scoreMultiplier;
        public LevelProgressionParameter[] levelProgressionParameters;
    }
}

