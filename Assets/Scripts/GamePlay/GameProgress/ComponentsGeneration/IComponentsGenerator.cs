using System.Collections;
using System.Collections.Generic;
using BurningSky.Data;
using UnityEngine;

namespace BurningSky.Gameplay
{
    public interface IComponentsGenerator
    {
        void StartGenerating(LevelConfig levelConfig);
        void StopGenerating();
    }
}
