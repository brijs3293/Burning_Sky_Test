using EA.BurningSky.Data;

namespace EA.BurningSky.Gameplay
{
    /// <summary>
    /// An interface for strategy pattern which provides abstraction for fleet creation
    /// </summary>
    public interface IFleetCreator
    {
        void CreateFleet(FleetConfig fleetConfig, float multiplier);
    }
}
