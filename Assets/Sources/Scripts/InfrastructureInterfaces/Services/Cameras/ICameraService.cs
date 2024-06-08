using System;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Cameras
{
    public interface ICameraService
    {
        event Action PositionChanged;
        ICameraPosition CurrentPosition { get; }

        void SetPosition(PositionId positionId);
        void AddPosition(ICameraPosition cameraPosition);
        ICameraPosition Get(PositionId positionId);
    }
}