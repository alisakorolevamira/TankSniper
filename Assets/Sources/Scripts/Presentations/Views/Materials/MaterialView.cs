using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.PresentationsInterfaces.Views.Materials;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Materials
{
    public class MaterialView : View, IMaterialView
    {
        [SerializeField] private MaterialType _materialType;
        [SerializeField] private Material _material;

        public MaterialType Type => _materialType;
        public Material Material => _material;
    }
}