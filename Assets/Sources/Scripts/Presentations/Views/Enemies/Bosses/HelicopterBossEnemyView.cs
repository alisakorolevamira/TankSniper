using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Presentations.Views.BossPeaces;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Bosses
{
    public class HelicopterBossEnemyView : MovingEnemyViewBase, IHelicopterBossEnemyView
    {
        [SerializeField] private HelicopterBossEnemyAnimation _enemyAnimation;
        [SerializeField] private List<HelicopterPeaceView> _peaces;
        [SerializeField] private HealthBarUI _healthBar;
        [SerializeField] private List<Transform> _rotors;
        [SerializeField] private float _rotationRotor = 1;

        public IEnemyAnimation EnemyAnimation => _enemyAnimation;
        public HealthBarUI HealthBar => _healthBar;

        public void RotateRotors()
        {
            foreach (Transform rotor in _rotors)
            {
                rotor.Rotate(new Vector3(0,0,_rotationRotor));
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IBulletView bulletView))
            {
                HelicopterPeaceView piece = _peaces.FirstOrDefault(x => x.IsDestroyed == false);
                piece?.Explode();
            }
        }
    }
}