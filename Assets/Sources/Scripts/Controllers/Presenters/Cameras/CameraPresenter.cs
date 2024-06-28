using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Cameras
{
    public class CameraPresenter : PresenterBase
    {
        private readonly ICameraView _cameraView;
        private readonly ICameraService _cameraService;
        
        private float _horizontal;
        private float _vertical;
        //private PositionId _currentPosition;
        
        private CancellationTokenSource _cancellationTokenSource;
        
        public CameraPresenter(ICameraView cameraView, ICameraService cameraService)
        {
            _cameraView = cameraView ?? throw new ArgumentNullException(nameof(cameraView));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }
        
        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cameraService.PositionChanged += OnChangedPosition;
            _cameraService.RotationChanged += OnChangedRotation;
        }

        public override void Disable()
        {
            _cameraService.PositionChanged -= OnChangedPosition;
            _cameraService.RotationChanged -= OnChangedRotation;
            _cancellationTokenSource.Cancel();
        }

        private async void OnChangedPosition(ICameraPosition position)
        {
            try
            {
                //_currentPosition = position.Id;
                
                while (Vector3.Distance(_cameraView.CurrentPosition, position.Position) > 0.001f)
                {
                    _cameraView.SetPosition(position.Position);

                    await UniTask.Yield(_cancellationTokenSource.Token);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void OnChangedRotation(Vector2 delta)
        {
            float time = Time.deltaTime;

            _vertical -= CameraConst.Sensitivity * delta.y * time;
            _horizontal += CameraConst.Sensitivity * delta.x * time;
            
            _vertical = Mathf.Clamp(_vertical, CameraConst.MinVerticalAngle, CameraConst.MaxVerticalAngle);
            _horizontal = Mathf.Clamp(_horizontal, CameraConst.MinHorizontalAngle, CameraConst.MaxHorizontalAngle);

            Vector3 rotation = new Vector3(_vertical, _horizontal, 0);
            
            _cameraView.SetRotation(rotation);
        }
    }
}