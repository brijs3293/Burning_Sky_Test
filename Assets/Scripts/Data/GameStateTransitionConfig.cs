using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurningSky.Data
{
    /// <summary>
    /// A Scriptable object for Gamestate Transitions. which contains information of whether state can transit to other state.
    /// </summary>
    [CreateAssetMenu(fileName = "GameStateTransitionConfig", menuName = "ScriptableObjects/GameStateTransitionConfig", order = 5)]
    public class GameStateTransitionConfig : StateTransitionConfig<GameState>
    {

    }
}
