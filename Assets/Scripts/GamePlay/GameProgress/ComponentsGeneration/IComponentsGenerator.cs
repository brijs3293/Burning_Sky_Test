using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public interface IComponentsGenerator
    {
        void StartGenerating(LevelConfig levelConfig);
        void StopGenerating();
    }
}
