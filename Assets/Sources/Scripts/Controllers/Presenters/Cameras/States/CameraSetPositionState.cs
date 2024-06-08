using System;
using Sources.Scripts.Infrastructure.StateMachines.ContextStateMachine.States;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Cameras.States
{
    public class CameraSetPositionState : ContextStateBase
    {
        private readonly ICinemachineCameraView _cinemachineCameraView;
        private readonly ICameraService _cameraService;

        public CameraSetPositionState(
            ICinemachineCameraView cinemachineCameraView,
            ICameraService cameraService)
        {
            _cinemachineCameraView = cinemachineCameraView ?? 
                                     throw new ArgumentNullException(nameof(cinemachineCameraView));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public override void Enter(object payload = null)
        {
            Vector3 position = _cameraService.Get(PositionId.MainPosition).Position;
            _cinemachineCameraView.SetPosition(position);
        }
    }
}