using System;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Players.Configs;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Materials;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Shop
{
    public class SkinChangerService : ISkinChangerService
    {
        private readonly PlayerViewMaterialsConfig _playerViewMaterialsConfig;
        
        private SkinChanger _skinChanger;

        public SkinChangerService(PlayerViewMaterialsConfig playerViewMaterialsConfig)
        {
            _playerViewMaterialsConfig = playerViewMaterialsConfig ? playerViewMaterialsConfig :
                throw new ArgumentNullException(nameof(playerViewMaterialsConfig));
        }

        public void ChangeSkin(SkinType skinType) => 
            _skinChanger.ChangeSkin(skinType);
        
        public void Construct(SkinChanger skinChanger) => 
            _skinChanger = skinChanger ?? throw new ArgumentNullException(nameof(skinChanger));

        public void ChangeMaterial(MaterialType materialType)
        {
            if (materialType == MaterialType.Default)
            {
                _skinChanger.SetDefaultMaterial();
                return;
            }
                
            MaterialView materialView = _playerViewMaterialsConfig.Materials.Find(x => x.Type == materialType);
            
            _skinChanger.ChangeMaterial(materialView.Material);
        }

        public void ChangeDecal(Sprite decal)
        {
            _skinChanger.ChangeDecal(decal);
        }
    }
}