using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents
{
    public interface INavMeshAgent : IView
    {
        public Vector3 Position { get; }

        void Move(Vector3 position);
        void Stop();
        void EnableNavmeshAgent();

        void DisableNavmeshAgent();
    }
}