using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Bullets
{
    public class BulletSpawnPoint : View, IBulletSpawnPoint
    {
        public Transform Transform => transform;
    }
}