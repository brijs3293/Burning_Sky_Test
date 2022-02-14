using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurningSky.Utility
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance;
        // Start is called before the first frame update
        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}
