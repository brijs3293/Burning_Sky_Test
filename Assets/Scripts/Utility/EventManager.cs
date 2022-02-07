using System;
using System.Collections.Generic;

namespace EA.BurningSky.Event
{
    public enum EventType
    {
        MouseDown
    }

    /// <summary>
    /// Class which handles Event related Stuff. Provides Observer pattern wrapping.
    /// </summary>
    public class EventManager
    {
        static Dictionary<EventType, Action> _actions = new Dictionary<EventType, Action>();
        static Dictionary<EventType, Action<object>> _actionsWithParam = new Dictionary<EventType, Action<object>>();

        public static void RegisterMethod(EventType type, Action action)
        {
            if (_actions.TryGetValue(type, out var storedAction))
            {
                storedAction += action;
            }
            else
            {
                Action actionToStore = action;
                _actions.Add(type, actionToStore);
            }
        }

        public static void UnRegisterMethod(EventType type, Action action)
        {
            _actions[type] -= action;
        }

        public static void RegisterMethod(EventType type, Action<object> action)
        {
            if (_actionsWithParam.TryGetValue(type, out var storedAction))
            {
                storedAction += action;
            }
            else
            {
                Action<object> actionToStore = action;
                _actionsWithParam.Add(type, actionToStore);
            }
        }

        public static void UnRegisterMethod(EventType type, Action<object> action)
        {
            _actionsWithParam[type] -= action;
        }

        public static void InvokeAction(EventType type)
        {
            if (_actions.TryGetValue(type, out var action))
            {
                action?.Invoke();
            }
        }

        public static void InvokeAction(EventType type, object param)
        {
            if (_actionsWithParam.TryGetValue(type, out var action))
            {
                action?.Invoke(param);
            }
        }

        public static void Dispose()
        {
            _actions.Clear();
            _actionsWithParam.Clear();
            _actions = null;
            _actionsWithParam = null;
        }
    }
}
