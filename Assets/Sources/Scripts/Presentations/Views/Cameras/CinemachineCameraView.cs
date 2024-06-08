using Cinemachine;
using Sources.Scripts.Controllers.Presenters.Cameras;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Cameras
{
    public class CinemachineCameraView : PresentableView<CameraPresenter>, ICinemachineCameraView
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public void SetPosition(Vector3 position, Quaternion rotation)
        {
            _cinemachineVirtualCamera.ForceCameraPosition(position, rotation);
        }
    }
}