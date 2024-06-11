using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Cameras
{
    public class CameraService : ICameraService
    {
        private Dictionary<PositionId, ICameraPosition> _cameraPositions = new ();
        
        public event Action PositionChanged;
        
        public ICameraPosition CurrentPosition { get; private set; }
        
        public void SetPosition(PositionId positionId)
        {
            if (_cameraPositions.ContainsKey(positionId) == false)
                throw new InvalidOperationException(nameof(positionId));
            
            ChangePosition(_cameraPositions[positionId].Position);
            
            CurrentPosition = _cameraPositions[positionId];
            PositionChanged?.Invoke();
        }

        public void AddPosition(ICameraPosition cameraPosition)
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

        private async void ChangePosition(Vector3 toPosition)
        {
            while (Vector3.Distance(CurrentPosition.Position, toPosition) > 0.001f)
            {
                CurrentPosition.Move(toPosition);
                await UniTask.Yield();
            }
        }
    }
}