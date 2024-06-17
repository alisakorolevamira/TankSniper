using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter
{
    public interface IHelicopterEnemyView : IEnemyViewBase
    {
        void Move(Vector3 target);
    }
}