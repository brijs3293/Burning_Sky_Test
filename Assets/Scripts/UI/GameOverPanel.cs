using BurningSky.Event;
using BurningSky.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using EventType = UnityEngine.EventType;

namespace BurningSky.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        #region Public_Variables
        public Text score;
        public Text highestScore;
        #endregion

        #region Private_Variables
        private ICommand _scoreUpdateCommand;
        #endregion

        #region Unity_Callbacks
        void Start()
        {
            EventManager.RegisterMethod(Event.EventType.ScoreUpdate, ScoreUpdateEvent);
        }

        void OnEnable()
        {
            Invoke(nameof(ScoreUpdateEvent), 0.1f);
        }

        void OnDestroy()
        {
            EventManager.UnRegisterMethod(Event.EventType.ScoreUpdate, ScoreUpdateEvent);
        }
        #endregion

        #region Public_Methods

        public void ScoreUpdateEvent()
        {
            _scoreUpdateCommand.Execute();
        }

        public void UpdateScore(int scoreValue, int highestScoreValue)
        {
            score.text = scoreValue.ToString();
            highestScore.text = highestScoreValue.ToString();
        }

        public void RestartGameClicked()
        {
            UiManager.Instance.RestartGame();
        }

        public void InjectDependency(ICommand command)
        {
            _scoreUpdateCommand = command;
        }
        #endregion
    }
}
