using Sources.Scripts.PresentationsInterfaces.Views.Items;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IItemSpawnService
    {
        IItemView Spawn(Vector3 position);
    }
}