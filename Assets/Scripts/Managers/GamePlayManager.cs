using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class GamePlayManager : MonoBehaviour
    {
        public static GamePlayManager Instance;

        // Start is called before the first frame update
        void Awake()
        {
            Instance = this;
        }


    }
}
