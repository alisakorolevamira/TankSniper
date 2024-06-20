using System;
using System.Collections.Generic;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Cameras
{
    public class CameraService : ICameraService
    {
        private readonly IInputService _inputService;
        private Dictionary<PositionId, ICameraPosition> _cameraPositions = new ();

        public CameraService(IInputService inputService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }
        
        public event Action<ICameraPosition> PositionChanged;
        public event Action<Vector2> RotationChanged;
        public ICameraPosition CurrentPosition { get; private set; }

        public void SetPosition(PositionId positionId)
        {
            if (_cameraPositions.ContainsKey(positionId) == false)
                throw new InvalidOperationException(nameof(positionId));
            
            CurrentPosition = _cameraPositions[positionId];
            PositionChanged?.Invoke(CurrentPosition);
        }

        public void AddPosition(CameraPositionView cameraPosition)
        {
            if (_cameraPositions.ContainsKey(cameraPosition.Id))
                throw new InvalidOperationException(nameof(cameraPosition.Id));
            
            _cameraPositions[cameraPosition.Id] = cameraPosition;
        }

        public ICameraPosition Get(PositionId positionId)
        {
            if (_cameraPositions.ContainsKey(positionId) == false)
                throw new InvalidOperationException(nameof(positionId));

            return _cameraPositions[positionId];
        }

        public void Enter(object payload = null) => 
            _inputService.RotationInputReceived += SetRotation;

        public void Exit() => 
            _inputService.RotationInputReceived -= SetRotation;

        private void SetRotation(Vector2 delta) => 
            RotationChanged?.Invoke(delta);
    }
}