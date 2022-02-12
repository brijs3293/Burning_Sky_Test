using EA.BurningSky.Event;
using EA.BurningSky.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace EA.BurningSky.UI
{
    public class HomePanel : MonoBehaviour
    {
        #region Public_Variables
        public Text highestScoreText;
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

        public void UpdateScore(int highestScoreValue)
        {
            highestScoreText.text = highestScoreValue.ToString();
        }

        public void PlayButtonClicked()
        {
            UiManager.Instance.StartGameplayClicked();
        }

        public void InjectDependency(ICommand command)
        {
            _scoreUpdateCommand = command;
        }
        #endregion
    }
}
