using EA.BurningSky.Event;
using EA.BurningSky.Gameplay;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using EventType = EA.BurningSky.Event.EventType;

namespace EA.BurningSky.UI
{
    public class GamePlayPanel : MonoBehaviour
    {
        #region Public_Variables
        public Text scoreText;
        public Text healthText;
        #endregion

        #region Private_Variables
        private ICommand _scoreUpdateCommand;
        #endregion

        #region Unity_Callbacks
        void Start()
        {
            EventManager.RegisterMethod(EventType.ScoreUpdate, ScoreUpdateEvent);
            EventManager.RegisterMethod(EventType.HealthUpdate, HealthUpdateEvent);
        }

        void OnEnable()
        {
            Invoke(nameof(ScoreUpdateEvent), 0.1f);
        }

        void OnDestroy()
        {
            EventManager.UnRegisterMethod(EventType.ScoreUpdate, ScoreUpdateEvent);
            EventManager.UnRegisterMethod(EventType.HealthUpdate, HealthUpdateEvent);
        }
        #endregion

        #region Public_Methods
        public void PauseButtonClicked()
        {
            UiManager.Instance.PauseGamePlayClicked();
        }

        public void ScoreUpdateEvent()
        {
            _scoreUpdateCommand.Execute();
        }

        public void HealthUpdateEvent(object health)
        {
            healthText.text = health.ToString();
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void InjectDependency(ICommand command)
        {
            _scoreUpdateCommand = command;
        }
        #endregion
    }
}
