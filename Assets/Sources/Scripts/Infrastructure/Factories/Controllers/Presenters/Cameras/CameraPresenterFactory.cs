using System;
using Sources.Scripts.Controllers.Presenters.Cameras;
using Sources.Scripts.Controllers.Presenters.Cameras.States;
using Sources.Scripts.Infrastructure.StateMachines.ContextStateMachine.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Cameras
{
    public class CameraPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly ICameraService _cameraService;

        public CameraPresenterFactory(
            IUpdateRegister updateRegister,
            ICameraService cameraService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }
        
        public CameraPresenter Create(ICinemachineCameraView cinemachineCameraView)
        {
            CameraSetPositionState setPositionState = new CameraSetPositionState(
                cinemachineCameraView, _cameraService);
            CameraIdleState idleState = new CameraIdleState();
            
            FuncContextTransition toSetPositionState = new FuncContextTransition(
                setPositionState, 
                context =>
                {
                    if (context is not ICameraPosition cameraPosition)
                        return false;

                    return true;
                });
            
            setPositionState.AddTransition(toSetPositionState);
            
            return new CameraPresenter(
                setPositionState, 
                _updateRegister,
                _cameraService);
        }
    }
}