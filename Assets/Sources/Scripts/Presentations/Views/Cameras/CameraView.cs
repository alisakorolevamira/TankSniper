using Sources.Scripts.Controllers.Presenters.Cameras;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Cameras
{
    public class CameraView : PresentableView<CameraPresenter>, ICameraView
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _speed;

        public Vector3 CurrentPosition => transform.position;

        public void SetPosition(Vector3 position)
        {
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, position, step);
        }

        public void SetRotation(Vector3 rotation)
        {
            transform.eulerAngles = rotation;
        }
    }
}