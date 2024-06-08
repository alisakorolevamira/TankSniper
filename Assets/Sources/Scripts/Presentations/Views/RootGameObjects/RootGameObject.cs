using Sources.Scripts.Presentations.Views.Cameras;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.RootGameObjects
{
    public class RootGameObject : View
    {
        [field: SerializeField] public CameraPositionView Position;
    }
}