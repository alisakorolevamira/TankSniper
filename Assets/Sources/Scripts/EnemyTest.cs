using UnityEngine;

namespace Sources.Scripts
{
    public class EnemyTest : MonoBehaviour, IDamageable
    {
        public void ApplyDamage(int damage)
        {
            Debug.Log("damage applied");
        }
    }
}