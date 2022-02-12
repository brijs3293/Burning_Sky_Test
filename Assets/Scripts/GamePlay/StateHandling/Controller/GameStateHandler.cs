using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// StateHandler claass for Gamestate
    /// </summary>
    public class GameStateHandler : StateHandler<GameState>
    {
        public GameStateHandler(StateTransitionConfig<GameState> stateTransitionConfig) : base(stateTransitionConfig)
        {
            _stateBehaviours = new Dictionary<GameState, IStateBehaviour>
            {
                {GameState.NotPlaying, new NotPlayingStateBehaviour()},
                {GameState.Playing, new PlayingStateBehaviour(new GameplayStateEnterCommand())},
                {GameState.Paused, new PausedStateBehaviour()},
                {GameState.GameOver, new GameOverStateBehaviour(new GameOverStateEnterCommand())}
            };
            //Initialize starting state
            currentState = GameState.NotPlaying;
            currentStateBehaviour = _stateBehaviours[GameState.NotPlaying];
        }
    }
}
