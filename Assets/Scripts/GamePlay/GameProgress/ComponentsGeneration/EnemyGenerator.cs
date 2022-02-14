using System.Collections;
using System.Collections.Generic;
using BurningSky.Data;
using BurningSky.Utility;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A class which generates enemy. Implements IComponentsGenerator so other class should be dependent on interface not on this class.
    /// </summary>
    public class EnemyGenerator : MonoBehaviour, IComponentsGenerator
    {
        #region Public_Variables

        public float startWaitTime;

        #endregion

        #region Private_Variables
        //Dictionary cache because enemy generation takes place periodically and no need to create new objects everytime.
        readonly Dictionary<FleetType, IFleetCreator> _fleetCreators = new Dictionary<FleetType, IFleetCreator>();
        private Coroutine _enemyGenerationRoutine;

        #endregion

        #region Unity_Callbacks

        void Start()
        {
            _fleetCreators.Add(FleetType.Fleet1, new Fleet1Creator());
            _fleetCreators.Add(FleetType.Fleet2, new Fleet2Creator());
            _fleetCreators.Add(FleetType.Fleet3, new Fleet3Creator());
        }

        #endregion

        #region Private_Methods

        void CreateFleet(FleetConfig fleetConfig, float multiplier)
        {
            _fleetCreators[fleetConfig.fleetType].CreateFleet(fleetConfig, multiplier);
        }

        #endregion

        #region Public_Methods
        /// <summary>
        /// Called from reference of IComponentsGenerator to generate enemies
        /// </summary>
        /// <param name="levelConfig"></param>
        public void StartGenerating(LevelConfig levelConfig)
        {
            if (_enemyGenerationRoutine != null)
            {
                StopCoroutine(_enemyGenerationRoutine);
            }
            _enemyGenerationRoutine = StartCoroutine(EnemyGenerationLoop(levelConfig));
        }

        /// <summary>
        /// Called from reference of IComponentsGenerator to stop generating enemies
        /// </summary>
        public void StopGenerating()
        {
            if (_enemyGenerationRoutine != null)
            {
                StopCoroutine(_enemyGenerationRoutine);
            }
        }

        /// <summary>
        /// Method provides movement objects that will be injected to enemycontroller
        /// </summary>
        /// <param name="movementTypeType"></param>
        /// <param name="speedMultiplier"></param>
        /// <returns></returns>
        public static IEnemyMovement GetMovementType(EnemyMovementType movementTypeType, float speedMultiplier = 1)
        {
            switch (movementTypeType)
            {
                case EnemyMovementType.Straight:
                    return new StraightEnemyMovement(speedMultiplier);
                case EnemyMovementType.Zigzag:
                    return new ZigZagEnemyMovement(speedMultiplier);
                case EnemyMovementType.Evasive:
                    return new EvasiveEnemyMovement(speedMultiplier);
            }
            return null;
        }

        #endregion

        #region Coroutines

        /// <summary>
        /// Coroutine that generates Enemies according to configuration given
        /// </summary>
        /// <param name="levelConfig"></param>
        /// <returns></returns>
        IEnumerator EnemyGenerationLoop(LevelConfig levelConfig)
        {
            yield return new WaitForSeconds(startWaitTime);
            int length = levelConfig.fleetConfigs.Length;
            for (int j = 0; j < length; j++)
            {
                CreateFleet(levelConfig.fleetConfigs[j], levelConfig.speedMultiplier);
                yield return new WaitForSeconds(levelConfig.fleetConfigs[j].timeToLetPass);
                if (j == levelConfig.fleetConfigs.Length - 1)
                {
                    j = 0;
                }
            }
        }

        #endregion
    }
}
