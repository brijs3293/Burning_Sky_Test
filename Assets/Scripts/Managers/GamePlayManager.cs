using System.Collections.Generic;
using BurningSky.Data;
using BurningSky.Event;
using BurningSky.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using EventType = BurningSky.Event.EventType;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A class responsible  for GAmeplay management
    /// </summary>
    public class GamePlayManager : Singleton<GamePlayManager>
    {
        #region Public_Variables

        public StateTransitionConfig<GameState> stateTransitionConfig;
        public GameObject player;
        public GameState CurrentState => _stateHandler.currentState;
        public bool IsPlayingState => CurrentState == GameState.Playing;

        #endregion

        #region Private_Variables
        private GameStateHandler _stateHandler;
        #endregion

        #region Unity_Callbacks
        // Start is called before the first frame update
        public override void Awake()
        {
            base.Awake();
            _stateHandler = new GameStateHandler(stateTransitionConfig);
        }

        void Start()
        {
            PreSetGame();
            EventManager.RegisterMethod(EventType.GameStart, StartGamePlay);
            EventManager.RegisterMethod(EventType.GamePause, Pause);
            EventManager.RegisterMethod(EventType.GameRestart, RestartGame);
        }

        void OnDestroy()
        {
            EventManager.UnRegisterMethod(EventType.GameStart, StartGamePlay);
            EventManager.UnRegisterMethod(EventType.GamePause, Pause);
            EventManager.UnRegisterMethod(EventType.GameRestart, RestartGame);
        }
        #endregion

        #region Public_Methods

        public void PreSetGame()
        {
            _stateHandler.TransitTo(GameState.NotPlaying);
        }

        public void StartGamePlay()
        {
            _stateHandler.TransitTo(GameState.Playing);
        }

        public void Pause()
        {
            _stateHandler.TransitTo(GameState.Paused);
        }

        public void GameOver()
        {
            if (_stateHandler.TransitTo(GameState.GameOver))
            {
                EventManager.InvokeAction(EventType.GameOver);
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion
    }
}
