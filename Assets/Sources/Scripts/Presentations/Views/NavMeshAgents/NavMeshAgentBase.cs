using Sources.Scripts.ControllersInterfaces.Presenters;
using Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Scripts.Presentations.Views.NavMeshAgents
{
    public abstract class NavMeshAgentBase<T> : PresentableView<T>, INavMeshAgent
        where T : IPresenter
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public Vector3 Position => transform.position;

        public float StoppingDistance => _navMeshAgent.stoppingDistance;

        protected NavMeshAgent NavMeshAgent => _navMeshAgent;

        public void Move(Vector3 position) =>
            _navMeshAgent.SetDestination(position);

        public void SetStoppingDistance(float stoppingDistance) =>
            _navMeshAgent.stoppingDistance = stoppingDistance;
    }
}