using System;
using System.Collections.Generic;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.Data
{
    /// <summary>
    /// Defines from state to states transitions Link
    /// </summary>
    [System.Serializable]
    public struct Transactables<T> : IEquatable<Transactables<T>> where T : IComparable, IConvertible, IFormattable
    {
        public T fromState;
        //Here we have list of possible transitions but if we have clear scope then we can add conditions also here.
        public List<T> toStates;

        public bool Equals(Transactables<T> other)
        {
            return Equals(fromState, other.fromState);
        }
    }



    /// <summary>
    /// Defines currentState interruption from interrupting state Link
    /// </summary>
    [System.Serializable]
    public struct Interruptables<T> : IEquatable<Interruptables<T>> where T : IComparable, IConvertible, IFormattable
    {
        public T interruptingState;
        //Here we have list of possible interruption but if we have clear scope then we can add conditions also here.
        public List<T> interruptableStates;

        public bool Equals(Interruptables<T> other)
        {
            return Equals(interruptingState, other.interruptingState);
        }
    }

    /// <summary>
    /// A generic Scriptable object which can be extended for any concrete type that is supported.
    /// </summary>
    public class StateTransitionConfig<T> : ScriptableObject where T :  IComparable, IConvertible, IFormattable
    {
        //Directly Dictionaries also possible if we implement custom drawer for dictionary
        public List<Transactables<T>> transactablesList = new List<Transactables<T>>();
        public List<Interruptables<T>> interruptablesList = new List<Interruptables<T>>();

        //Dictionary used so that serach operation becomes fast
        readonly Dictionary<T, List<T>> _transactableDictionary = new Dictionary<T, List<T>>();

        readonly Dictionary<T, List<T>> _interruptableDictionary = new Dictionary<T, List<T>>();

        void OnEnable()
        {
            //Converting Lists to Dictionaries for search efficiency
            for (int i = 0; i < transactablesList.Count; i++)
            {
                _transactableDictionary.Add(transactablesList[i].fromState, transactablesList[i].toStates);
            }

            for (int i = 0; i < interruptablesList.Count; i++)
            {
                _interruptableDictionary.Add(interruptablesList[i].interruptingState, interruptablesList[i].interruptableStates);
            }
        }

        //Responsible to give result based on database
        public bool CanTransitionOccur(T currentState, T nextState)
        {
            return _transactableDictionary[currentState].Contains(nextState);
        }

        //Responsible to give result based on database
        public bool CanInterruptionOccur(T currentState, T interruptingState)
        {
            return _interruptableDictionary.Count == 0 || _interruptableDictionary[interruptingState].Contains(currentState);
        }
    }
}
