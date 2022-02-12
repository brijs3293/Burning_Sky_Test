using System;
using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using EA.BurningSky.Event;
using EA.BurningSky.Utility;
using UnityEngine;
using EventType = EA.BurningSky.Event.EventType;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A custom data type where data of progression and current progress is encapsulated
    /// </summary>
    public struct LevelProgressData
    {
        public LevelProgressionParameter levelProgressionParameter;
        public float currentValue;
    }

    /// <summary>
    /// A class which tracks progress of gameplay including difficulty level and Score.
    /// </summary>
    public class GameProgression : Singleton<GameProgression>
    {
        #region Public_Variables

        public LevelConfig[] levels;
        public int timeCalculationInterval = 1;
        public ScoringSystem scoringSystem;

        #endregion

        #region Private_Variables

        private int _currentIndex = -1;
        //Array of components generator. Composition of interface over concrete class.
        private IComponentsGenerator[] _componentsGenerators;
        Dictionary<LevelProgressionParam, LevelProgressData> _currentLevelProgressData = new Dictionary<LevelProgressionParam, LevelProgressData>();
        private LevelConfig _currentLevelConfig;
        private Coroutine _timeCoroutine;
        private Action<int> _scoreUpdate;
        private Action<int> _timeUpdate;
        #endregion

        #region Unity_Callbacks

        public override void Awake()
        {
            base.Awake();
            scoringSystem = new ScoringSystem();
        }

        void Start()
        {
            _componentsGenerators = GetComponents<IComponentsGenerator>();
        }

        #endregion

        #region Private_Methods

        /// <summary>
        /// Methods tracks score from start of difficulty level.
        /// </summary>
        /// <param name="score"></param>
        void ScoreUpdated(int score)
        {
            LevelProgressData data = _currentLevelProgressData[LevelProgressionParam.Score];
            data.currentValue += score;
            _currentLevelProgressData[LevelProgressionParam.Score] = data;
            if (CanIncreaseDifficultyLevel())
            {
                NextDifficultyLevel();
            }
        }

        /// <summary>
        /// Methods tracks time from start of difficulty level.
        /// </summary>
        /// <param name="score"></param>
        void TimeUpdated(int time)
        {
            LevelProgressData data = _currentLevelProgressData[LevelProgressionParam.Time];
            data.currentValue += time;
            _currentLevelProgressData[LevelProgressionParam.Time] = data;
            if (CanIncreaseDifficultyLevel())
            {
                NextDifficultyLevel();
            }
        }

        /// <summary>
        /// Checks whether all conditions meet for difficulty level to proceed.
        /// </summary>
        /// <returns></returns>
        bool CanIncreaseDifficultyLevel()
        {
            bool can = true;
            foreach (var levelProgress in _currentLevelProgressData)
            {
                if (levelProgress.Value.currentValue < levelProgress.Value.levelProgressionParameter.value)
                {
                    can = false;
                }
            }
            return can;
        }

        #endregion

        #region Public_Methods
        /// <summary>
        /// Go to next difficulty level
        /// </summary>
        public void NextDifficultyLevel()
        {
            Debug.Log("Next difficulty Level");
            _currentIndex++;
            if (_currentIndex >= levels.Length)
            {
                Debug.Log("All Difficulty level completed. Game Level Up starting new level ");
                _currentIndex = 0;
            }
            _currentLevelConfig = levels[_currentIndex];
            _currentLevelProgressData.Clear();
            int length = _currentLevelConfig.levelProgressionParameters.Length;
            if (_timeCoroutine != null)
            {
                StopCoroutine(_timeCoroutine);
            }

            for (int i = 0; i < length; i++)
            {
                //Initializing difficultylevel progress parameters
                LevelProgressData levelProgressData;
                levelProgressData.levelProgressionParameter = _currentLevelConfig.levelProgressionParameters[i];
                levelProgressData.currentValue = 0;
                _currentLevelProgressData.Add(levelProgressData.levelProgressionParameter.param, levelProgressData);
                switch (levelProgressData.levelProgressionParameter.param)
                {
                    case LevelProgressionParam.Time:
                        _timeCoroutine = StartCoroutine(TimeCalculator());
                        _timeUpdate = TimeUpdated;
                        break;
                    case LevelProgressionParam.Score:
                        _scoreUpdate = ScoreUpdated;
                        break;
                }
            }
            //Starting generating required components as per configuration
            length = _componentsGenerators.Length;
            for (int i = 0; i < length; i++)
            {
                _componentsGenerators[i].StartGenerating(_currentLevelConfig);
            }
        }

        public void Score(int score)
        {
            scoringSystem.Score += score;
            _scoreUpdate?.Invoke(score);
            EventManager.InvokeAction(EventType.ScoreUpdate);
        }

        /// <summary>
        /// Stops all generations operation 
        /// </summary>
        public void StopDifficultyProgression()
        {
            if (_timeCoroutine != null)
            {
                StopCoroutine(_timeCoroutine);
            }
            _currentLevelProgressData.Clear();
            _scoreUpdate = null;
            _timeUpdate = null;
            int length = _componentsGenerators.Length;
            for (int i = 0; i < length; i++)
            {
                _componentsGenerators[i].StopGenerating();
            }
        }

        #endregion

        #region Coroutines
        /// <summary>
        /// Time tracker if required for level to complete
        /// </summary>
        /// <returns></returns>
        IEnumerator TimeCalculator()
        {
            WaitForSeconds wait = new WaitForSeconds(timeCalculationInterval);
            while (true)
            {
                yield return wait;
                _timeUpdate?.Invoke(timeCalculationInterval);
            }
        }

        #endregion

    }
}
