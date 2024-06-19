using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IInventoryTankSpawnerService
    {
        IInventoryTankView Spawn(int level);
    }
}