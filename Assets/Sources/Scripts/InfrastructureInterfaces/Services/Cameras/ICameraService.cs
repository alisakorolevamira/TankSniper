using System;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Cameras
{
    public interface ICameraService
    {
        event Action<ICameraPosition> PositionChanged;
        event Action<Vector2> RotationChanged;
        ICameraPosition CurrentPosition { get; }

        void SetPosition(PositionId positionId);
        void AddPosition(CameraPositionView cameraPosition);
        ICameraPosition Get(PositionId positionId);
    }
}