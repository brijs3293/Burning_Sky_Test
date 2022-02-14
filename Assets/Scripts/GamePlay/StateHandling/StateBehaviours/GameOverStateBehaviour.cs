namespace BurningSky.Gameplay
{
    /// <summary>
    /// Class represents GameOver state  behaviour
    /// </summary>
    public class GameOverStateBehaviour : IStateBehaviour
    {
        private ICommand _enterCommand;

        public GameOverStateBehaviour(ICommand enterCommand)
        {
            _enterCommand = enterCommand;
        }

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
            //GameProgression.Instance.StopDifficultyProgression();
            _enterCommand.Execute();
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
