﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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
        
        private float _horizontal = 0;
        private float _vertical = 0;
        private float _sensitivity = 15;
        private float _minVerticalAngle = -15;
        private float _maxVerticalAngle = 15;
        private float _minHorizontalAngle = -15;
        private float _maxHorizontalAngle = 15;
        private PositionId _currentPosition;
        
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
                _currentPosition = position.Id;
                
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

            _vertical -= _sensitivity * delta.y * time;
            _horizontal += _sensitivity * delta.x * time;

            if (_currentPosition == PositionId.MainPosition)
            {
                _minVerticalAngle = -15;
                _maxVerticalAngle = 15;
                _minHorizontalAngle = -15;
                _maxHorizontalAngle = 15;
            }

            else
            {
                _minVerticalAngle = -20;
                _maxVerticalAngle = 60;
                _minHorizontalAngle = -40;
                _maxHorizontalAngle = 40;
            }
            
            _vertical = Mathf.Clamp(_vertical, _minVerticalAngle, _maxVerticalAngle);
            _horizontal = Mathf.Clamp(_horizontal, _minHorizontalAngle, _maxHorizontalAngle);

            Vector3 rotation = new Vector3(_vertical, _horizontal, 0);
            
            _cameraView.SetRotation(rotation);
        }
    }
}