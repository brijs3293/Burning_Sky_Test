using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// Very simple scoring system
    /// </summary>
    public class ScoringSystem
    {
        public int highestScore;
        private int _currentScore;

        public ScoringSystem()
        {
            highestScore = PlayerPrefs.GetInt("highest", 0);
        }

        public int Score
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                if (highestScore < _currentScore)
                {
                    highestScore = _currentScore;
                    PlayerPrefs.SetInt("highest", highestScore);
                }
            }
        }
    }
}
