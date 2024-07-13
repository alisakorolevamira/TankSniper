using Sources.Scripts.Presentations.Views.Stickman;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Stickman
{
    public interface IStickmanView
    {
        StickmanType StickmanType { get; }
        Vector3 CurrentScale { get; }

        void SetScale(Vector3 scale);
    }
}