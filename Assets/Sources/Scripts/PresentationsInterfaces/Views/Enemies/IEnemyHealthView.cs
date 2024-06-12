using Sources.Scripts.Presentations.Views.Common;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyHealthView
    {
        float CurrentHealth { get; }

        void TakeDamage(float damage);
    }
}