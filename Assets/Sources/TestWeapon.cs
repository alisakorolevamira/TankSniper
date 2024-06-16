using Sources.Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TestWeapon : MonoBehaviour
{
    [SerializeField] private Transform _rigidbodyy;
    [SerializeField] private Button _button;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private void OnEnable()
    {
        _button.onClick.AddListener(PerformAttack);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PerformAttack);
    }

    private void PerformAttack()
    {
        _navMeshAgent.SetDestination(_rigidbodyy.position);
    }
}
