using BurningSky.Data;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// An interface to mark object to consume power. It also removes dependency over concrete class. 
    /// </summary>
    public interface IPowerEffector
    {
        void ApplyPower(PowerConfig powerConfig);
        float GetApplicableValue(PowerUpType type, float value);
    }
}
