using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.UIFramework.Presentations.Images;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Players
{
    public interface ISkinView
    {
        SkinType SkinType { get; }
        Vector3 CurrentScale { get; }
        ImageView DecalImage { get; }

        void SetScale(Vector3 scale);
    }
}