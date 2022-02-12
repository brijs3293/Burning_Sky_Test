using EA.BurningSky.Event;
using EA.BurningSky.Gameplay;
using UnityEngine;
using EventType = EA.BurningSky.Event.EventType;

namespace EA.BurningSky.UI
{
    public class UiManager : MonoBehaviour
    {
        #region Public_Variables
        public static UiManager Instance;
        public HomePanel homePanel;
        public GamePlayPanel gamePlayPanel;
        public PausePanel pausePanel;
        public GameOverPanel gameOverPanel;
        #endregion

        #region Private_Variables
        private GameObject _currentPanel;
        #endregion

        #region Unity_Callbacks

        void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            EventManager.RegisterMethod(EventType.GameOver, GamePlayOver);
            //Injecting dependency here for score update command
            gamePlayPanel.InjectDependency(new InGameplayScoreShowCommand());
            gameOverPanel.InjectDependency(new GameOverScoreShowCommand());
            homePanel.InjectDependency(new HomePanelScoreShowCommand());
            SetCurrentPanel(homePanel.gameObject);
        }

        void OnDestroy()
        {
            EventManager.UnRegisterMethod(EventType.GameOver, GamePlayOver);
        }

        #endregion

        #region Public_Methods
        public void StartGameplayClicked()
        {
            EventManager.InvokeAction(EventType.GameStart);
            SetCurrentPanel(gamePlayPanel.gameObject);
        }

        public void PauseGamePlayClicked()
        {
            EventManager.InvokeAction(EventType.GamePause);
            SetCurrentPanel(pausePanel.gameObject);
        }

        public void GamePlayOver()
        {
            SetCurrentPanel(gameOverPanel.gameObject);
        }

        public void RestartGame()
        {
            EventManager.InvokeAction(EventType.GameRestart);
        }

        public void HomeButtonClicked()
        {
            SetCurrentPanel(homePanel.gameObject);
        }
        #endregion

        #region Private_methods
        private void SetCurrentPanel(GameObject newPanel)
        {
            if (_currentPanel)
            {
                _currentPanel.SetActive(false);
            }
            _currentPanel = newPanel;
            _currentPanel.SetActive(true);
        }
        #endregion
    }
}
