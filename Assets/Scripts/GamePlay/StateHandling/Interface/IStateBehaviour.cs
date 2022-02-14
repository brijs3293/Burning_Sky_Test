namespace BurningSky.Gameplay
{
    /// <summary>
    /// Template for state behaviours
    /// </summary>
    public interface IStateBehaviour
    {
        /// <summary>
        /// Decides based on data and other logic that a transition can occur at this stage or not.
        /// </summary>
        /// <returns></returns>
        bool CanTransitToAnotherState();
        /// <summary>
        /// Give required data
        /// </summary>
        /// <param name="input"></param>
        void FeedInput(object input);
        /// <summary>
        /// Action to perform when execution enters state
        /// </summary>
        void OnEnterState();
        /// <summary>
        /// Action to perform when execution exits state
        /// </summary>
        void OnExitState();
        /// <summary>
        /// Action to perform on interruption
        /// </summary>
        void OnInterruption();
    }
}
