using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Spawners
{
    public class PlayerSpawnPoint : View, IPlayerSpawnPoint
    {
        public Vector3 Position => transform.position;
    }
}