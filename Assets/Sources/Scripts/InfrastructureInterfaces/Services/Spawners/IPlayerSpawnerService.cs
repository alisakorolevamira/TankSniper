using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IPlayerSpawnerService : IEnable, IDisable
    {
        IPlayerView Spawn(Player player, int level);
    }
}