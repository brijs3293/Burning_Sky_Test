using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A Command to stop Game Progression. This removes dependency from calling class.
    /// </summary>
    public class GameOverStateEnterCommand : ICommand
    {
        public void Execute()
        {
            GameProgression.Instance.StopDifficultyProgression();
        }
    }
}
