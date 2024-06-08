using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Cameras
{
    public class CameraPositionView : View, ICameraPosition
    {
        [SerializeField] private PositionId _id;
        [SerializeField] private Transform _transform;

        public PositionId Id => _id;
        public Vector3 Position => _transform.position;
        public Quaternion Rotation => _transform.rotation;
    }
}