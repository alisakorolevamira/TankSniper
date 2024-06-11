using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Cameras
{
    public interface ICameraPosition : IContext
    {
        PositionId Id { get; }
        Vector3 Position { get; }
        Quaternion Rotation { get; }

        void Move(Vector3 toPosition);
    }
}