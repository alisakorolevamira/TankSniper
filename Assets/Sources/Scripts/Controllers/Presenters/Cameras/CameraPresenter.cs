using System;
using Sources.Scripts.ControllersInterfaces.Presenters;
using Sources.Scripts.Infrastructure.StateMachines.ContextStateMachine;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Scripts.Controllers.Presenters.Cameras
{
    public class CameraPresenter : ContextStateMachine, IPresenter
    {
        private readonly IContextState _firstState;
        private readonly IUpdateRegister _updateRegister;
        private readonly ICameraService _cameraService;
        
        public CameraPresenter(
            IContextState firstState, 
            IUpdateRegister updateRegister, 
            ICameraService cameraService) 
            : base(firstState)
        {
            _firstState = firstState ?? throw new ArgumentNullException(nameof(firstState));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }
        
        public void Enable()
        {
            Run();
            _updateRegister.UpdateChanged += Update;
            _cameraService.PositionChanged += OnPositionChanged;
        }

        public void Disable()
        {
            _updateRegister.UpdateChanged -= Update;
            _cameraService.PositionChanged -= OnPositionChanged;
            Stop();
        }

        private void OnPositionChanged() =>
            Apply(_cameraService.CurrentPosition);
    }
}