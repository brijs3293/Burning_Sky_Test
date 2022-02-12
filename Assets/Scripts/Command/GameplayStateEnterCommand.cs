using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A Command to start Game Progression. This removes dependency from calling class.
    /// </summary>
    public class GameplayStateEnterCommand : ICommand
    {
        public void Execute()
        {
            GameProgression.Instance.NextDifficultyLevel();
        }
    }
}
