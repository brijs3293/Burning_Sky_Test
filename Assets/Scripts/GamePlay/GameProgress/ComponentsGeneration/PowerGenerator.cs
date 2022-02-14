using System;
using System.Collections;
using System.Collections.Generic;
using BurningSky.Data;
using BurningSky.ObjectPool;
using BurningSky.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A class which generates Powers. Implements IComponentsGenerator so other class should be dependent on interface not on this class.
    /// </summary>
    public class PowerGenerator : MonoBehaviour, IComponentsGenerator
    {
        #region Variables
        public float startWaitTime;
        private Coroutine _powerGenerationRoutine;
        #endregion

        #region Public_Methods

        public void StartGenerating(LevelConfig levelConfig)
        {
            StopGenerating();
            _powerGenerationRoutine = StartCoroutine(PowerGenerationRoutine(levelConfig));
        }

        public void StopGenerating()
        {
            if (_powerGenerationRoutine != null)
            {
                StopCoroutine(_powerGenerationRoutine);
            }
        }
        #endregion

        #region Coroutines
        /// <summary>
        /// A coroutine that generates powers as per configuration
        /// </summary>
        /// <param name="levelConfig"></param>
        /// <returns></returns>
        IEnumerator PowerGenerationRoutine(LevelConfig levelConfig)
        {
            yield return new WaitForSeconds(startWaitTime);
            PowerUpType[] types = levelConfig.powersSupported;

            while (true)
            {
                Vector3 position = new Vector3(0, 0, BoundaryDetector.screenBoundary.y + 0.3f);
                Transform power = PoolManager.Spawn((types[Random.Range(0, types.Length)]).ToEnum<PoolNames>());
                power.position = position;
                yield return new WaitForSeconds(10);
            }
        }
        #endregion
    }
}
