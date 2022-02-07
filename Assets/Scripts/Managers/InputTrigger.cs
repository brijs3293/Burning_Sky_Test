using EA.BurningSky.Event;
using UnityEngine;
using EventType = UnityEngine.EventType;

namespace EA.BurningSky.Event
{
    /// <summary>
    /// A class which triggers input events using EventManager
    /// </summary>
    public class InputTrigger : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                EventManager.InvokeAction(EventType.MouseDown, Input.mousePosition);
            }
        }
    }
}
