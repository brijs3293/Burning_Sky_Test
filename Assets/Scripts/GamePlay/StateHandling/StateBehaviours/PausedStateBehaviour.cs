using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// Class represents Paused state  behaviour
    /// </summary>
    public class PausedStateBehaviour : IStateBehaviour
    {
        public bool CanTransitToAnotherState()
        {
            //Determine if we can move from this state to another state or not from this state data
            return true;
        }

        public void FeedInput(object input)
        {
            //Accept input provided to be used for execution before state transition occur
        }

        public void OnEnterState()
        {
            //Perform actions based on behaviour
            Time.timeScale = 0;
        }

        public void OnExitState()
        {
            //Perform actions based on behaviour
            Time.timeScale = 1;
        }

        public void OnInterruption()
        {
            //Perform actions based on behaviour
        }
    }
}
