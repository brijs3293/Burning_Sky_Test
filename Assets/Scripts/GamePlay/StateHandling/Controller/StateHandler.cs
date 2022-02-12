using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using EA.BurningSky.Data;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// Class responsible to manage states of Game
    /// This class makes cleaner and extendible code. If want to add new states and behaviour it can be very easy and code remains structured.
    /// It eliminates so many conditions and if - elseif ladders and modification when adding new state or removing one. Just have to implement in new class or remove and change StateTransitionData scriptable object.
    /// </summary>
    public class StateHandler<T> where T : IComparable, IConvertible, IFormattable
    {
        #region Public_Variables
        /// <summary>
        /// State of Game at this moment
        /// </summary>
        public T currentState;

        /// <summary>
        /// Behaviour of current state
        /// </summary>
        public IStateBehaviour currentStateBehaviour;

        /// <summary>
        /// State transition database useful in transition
        /// </summary>
        public StateTransitionConfig<T> stateTransitionConfig;

        #endregion

        #region Private_Variables
        /// <summary>
        /// State --> StateBehaviour Mapping
        /// </summary>
        protected Dictionary<T, IStateBehaviour> _stateBehaviours = new Dictionary<T, IStateBehaviour>();

        #endregion

        public StateHandler(StateTransitionConfig<T> stateTransitionConfig)
        {
            this.stateTransitionConfig = stateTransitionConfig;
        }

        #region Public_Methods
        /// <summary>
        /// Checks if transition to nextState is allowed or not
        /// </summary>
        /// <param name="nextState"></param>
        /// <returns></returns>
        public bool CanTransitToState(T nextState)
        {
            //Logic to find whether it is possible or not based on database or current state data. Determine whether nextState can interrupt currentState
            //Use _stateTransitionData
            return stateTransitionConfig.CanTransitionOccur(currentState, nextState);
        }

        /// <summary>
        /// Make transition to next state
        /// </summary>
        /// <param name="nextState"></param>
        /// <returns></returns>
        public bool TransitTo(T nextState)
        {
            if (currentStateBehaviour.CanTransitToAnotherState() && stateTransitionConfig.CanTransitionOccur(currentState, nextState))
            {
                currentStateBehaviour.OnExitState();
                currentStateBehaviour = _stateBehaviours[nextState];
                currentStateBehaviour.OnEnterState();
                currentState = nextState;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Interrupt current state if all conditions meet
        /// </summary>
        /// <param name="interruptingState"></param>
        /// <returns></returns>
        public bool InterruptCurrentState(T interruptingState)
        {
            if (stateTransitionConfig.CanInterruptionOccur(currentState, interruptingState))
            {
                currentStateBehaviour.OnInterruption();
                currentStateBehaviour.OnExitState();
                currentStateBehaviour = _stateBehaviours[interruptingState];
                currentStateBehaviour.OnEnterState();
                currentState = interruptingState;
                return true;
            }
            return false;
        }
        #endregion

    }
}
