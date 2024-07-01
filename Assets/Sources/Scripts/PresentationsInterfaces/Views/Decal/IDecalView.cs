using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Decal
{
    public interface IDecalView
    {
        DecalType Type { get; }
        Sprite Decal { get; }
    }
}