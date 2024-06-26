using Sources.Scripts.Presentations.Views.Players.SkinTypes;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Players
{
    public interface ISkinView
    {
        SkinType SkinType { get; }
        Vector3 CurrentScale { get; }

        void SetScale(Vector3 scale);
    }
}