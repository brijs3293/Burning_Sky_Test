using EA.BurningSky.Data;
using EA.BurningSky.ObjectPool;
using EA.BurningSky.Utility;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A concrete implementation of fleet creation
    /// </summary>
    public class Fleet1Creator : IFleetCreator
    {
        public void CreateFleet(FleetConfig fleetConfig, float multiplier)
        {
            Vector3 position = new Vector3(Random.Range(-BoundaryDetector.screenBoundary.x, BoundaryDetector.screenBoundary.x), 0, BoundaryDetector.screenBoundary.y);

            for (int i = 0; i < fleetConfig.numberOfEnemy; i++)
            {
                EnemyController controller = PoolManager.Spawn((fleetConfig.enemyType).ToEnum<PoolNames>()).GetComponent<EnemyController>();
                //Injecting movmenttype
                controller.SetMovement(EnemyGenerator.GetMovementType(fleetConfig.movementTypeType));
                controller.transform.position = position + Vector3.forward * i * 0.1f * ((int)fleetConfig.enemyType + 1);
                controller.transform.forward = -Vector3.forward;
            }
        }
    }
}
