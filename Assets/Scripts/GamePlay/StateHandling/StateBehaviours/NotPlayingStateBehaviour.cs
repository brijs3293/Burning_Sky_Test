namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// Class represents NotPlaying state  behaviour
    /// </summary>
    public class NotPlayingStateBehaviour : IStateBehaviour
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
        }

        public void OnExitState()
        {
            //Perform actions based on behaviour
        }

        public void OnInterruption()
        {
            //Perform actions based on behaviour
        }
    }
}
