using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Players.Skins
{
    public class SkinView : View, ISkinView
    {
        [SerializeField] private SkinType _skinType;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _defaultMaterial;

        public SkinType SkinType => _skinType;
        public Vector3 CurrentScale => transform.localScale;

        public void SetScale(Vector3 scale) => 
            transform.localScale = Vector3.MoveTowards(transform.localScale, scale, InventoryTankConst.DistanceDelta);

        public void SetMaterial(Material material) => 
            _renderer.sharedMaterial = material;
    }
}