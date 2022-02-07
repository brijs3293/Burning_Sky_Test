using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Data
{
    public enum EnemyType
    {
        Small1,
        Small2,
        Medium1,
        Medium2,
        Boss
    }

    public enum PowerUpType
    {
        Shield,
        ShootingBoost
    }

    public enum BulletType
    {
        Bullet1,
        Bullet2,
        Bullet3
    }

    public enum DifficultyLevel
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }
    
    public enum PoolNames
    {
        Bullet1,
        Bullet2,
        Bullet3,
        Enemy1,
        Enemy2,
        Enemy3,
        Enemy4,
        Enemy5,
        BulletParticle1,
        BulletParticle2,
        BulletParticle3,
    }

    public enum RewardType
    {
        Score
    }

    public enum FleetType
    {
        Fleet1,
        Fleet2,
        Fleet3
    }

    public enum EnemyMovementType
    {
        Straight,
        Zigzag,
        Evasive
    }

    public enum LevelProgressionParam
    {
        Time,
        Score
    }
}
