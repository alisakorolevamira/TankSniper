using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Presentations.Views.BossPeaces;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boss
{
    public class BossEnemyView : EnemyViewBase, IBossEnemyView
    {
        [SerializeField] private BossEnemyAnimation _bossEnemyAnimation;
        [SerializeField] private List<Transform> _movementPoints;
        [SerializeField] private List<BossPieceView> _peaces;

        public BossEnemyAnimation EnemyAnimation => _bossEnemyAnimation;
        public IReadOnlyList<Transform> MovementPoints => _movementPoints;
        public Vector3 Position => transform.position;

        public void MoveToPoint(Vector3 direction) => 
            transform.position = Vector3.MoveTowards(transform.position, direction, 0.2f * Time.deltaTime);

        public void SetRotation(float angle) => 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,angle, 0), 4f);

        public void Explode()
        {
            foreach (BossPieceView peace in _peaces)
            {
                if (peace.IsDestroyed == false) 
                    peace.Explode();
            }
            
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IBulletView bulletView))
            {
                BossPieceView piece = _peaces.First(p => p.IsDestroyed == false);
                piece.Explode();
            }
        }
    }
}