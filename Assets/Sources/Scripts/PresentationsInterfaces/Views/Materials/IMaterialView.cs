using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Materials
{
    public interface IMaterialView
    {
        MaterialType Type { get; }
        Material Material { get; }
    }
}