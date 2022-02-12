using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.UI;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A Command to show ingameplay score. This removes dependency from calling class. Event can be used but what if event do not occur and still want to update score in Ui let say start of game. 
    /// </summary>
    public class InGameplayScoreShowCommand : ICommand
    {
        public void Execute()
        {
            UiManager.Instance.gamePlayPanel.UpdateScore(GameProgression.Instance.scoringSystem.Score);
        }
    }

    /// <summary>
    /// A Command to show score and highest score On gameover panel. This removes dependency from calling class. Event can be used but what if event do not occur and still want to update score.
    /// </summary>
    public class GameOverScoreShowCommand : ICommand
    {
        public void Execute()
        {
            UiManager.Instance.gameOverPanel.UpdateScore(GameProgression.Instance.scoringSystem.Score, GameProgression.Instance.scoringSystem.highestScore);
        }
    }

    /// <summary>
    /// A Command to show score on home panel. This removes dependency from calling class. Event can be used but what if event do not occur and still want to update score in Ui let say start of game. 
    /// </summary>
    public class HomePanelScoreShowCommand : ICommand
    {
        public void Execute()
        {
            UiManager.Instance.homePanel.UpdateScore(GameProgression.Instance.scoringSystem.highestScore);
        }
    }


}
