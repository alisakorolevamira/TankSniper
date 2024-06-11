using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Cameras
{
    public class CameraPositionView : View, ICameraPosition
    {
        [SerializeField] private PositionId _id;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed;

        public PositionId Id => _id;
        public Vector3 Position => _transform.position;
        public Quaternion Rotation => _transform.rotation;

        public void Move(Vector3 toPosition)
        {
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, toPosition, step);
        }
    }
}