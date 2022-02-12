using System;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// An interface which marks game object to get damage in game.
    /// </summary>
    public interface IDamagable
    {
        void Damage(float damage);
        Action KillPlayer { get; set; }
    }
}
