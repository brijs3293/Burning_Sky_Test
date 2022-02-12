using System;
using EA.BurningSky.Data;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// A concrete implementation of Shooting booster
    /// </summary>
    public class ShootingBoostPowerEffect : ShieldPowerEffect
    {
        public ShootingBoostPowerEffect(ref Action updateAction) : base(ref updateAction)
        {
        }
    }
}
