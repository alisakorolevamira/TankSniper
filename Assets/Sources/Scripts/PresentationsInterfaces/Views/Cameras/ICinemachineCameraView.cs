using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Cameras
{
    public interface ICinemachineCameraView : IView
    {
        void SetPosition(Vector3 position, Quaternion rotation);
    }
}