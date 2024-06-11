using Sources.Scripts.Presentations.Views.Cameras.Types;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Cameras
{
    public interface ICameraPosition
    {
        PositionId Id { get; }
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}