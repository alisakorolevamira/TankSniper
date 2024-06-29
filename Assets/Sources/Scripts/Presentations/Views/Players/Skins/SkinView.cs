using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using Sources.Scripts.UIFramework.Presentations.Images;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Players.Skins
{
    public class SkinView : View, ISkinView
    {
        [SerializeField] private SkinType _skinType;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private ImageView _decalImage;

        public SkinType SkinType => _skinType;
        public Vector3 CurrentScale => transform.localScale;
        public ImageView DecalImage => _decalImage;

        public void SetScale(Vector3 scale) => 
            transform.localScale = Vector3.MoveTowards(transform.localScale, scale, InventoryTankConst.DistanceDelta);

        public void SetMaterial(Material material) => 
            _renderer.sharedMaterial = material;

        public void SetDefaultMaterial() => 
            _renderer.sharedMaterial = _defaultMaterial;

        public void SetDecal(Sprite sprite)
        {
            _decalImage.ShowImage();
            _decalImage.SetSprite(sprite);
        }
    }
}