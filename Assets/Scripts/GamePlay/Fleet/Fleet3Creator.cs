using EA.BurningSky.Data;
using EA.BurningSky.ObjectPool;
using EA.BurningSky.Utility;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A concrete implementation of fleet creation
    /// </summary>
    public class Fleet3Creator : IFleetCreator
    {
        public void CreateFleet(FleetConfig fleetConfig, float multiplier)
        {
            Vector3 position = new Vector3(0, 0, BoundaryDetector.screenBoundary.y);
            int sign = 1;
            for (int i = 0; i < fleetConfig.numberOfEnemy; i++)
            {
                EnemyController controller = PoolManager.Spawn((fleetConfig.enemyType).ToEnum<PoolNames>()).GetComponent<EnemyController>();
                //Injecting movmenttype
                controller.SetMovement(EnemyGenerator.GetMovementType(fleetConfig.movementTypeType));
                controller.transform.position = position + Vector3.right * i * 0.1f * ((int)fleetConfig.enemyType + 1) * sign + Vector3.forward * i * 0.1f * ((int)fleetConfig.enemyType + 1);
                controller.transform.forward = -Vector3.forward;
                sign = -sign;
            }
        }
    }
}
