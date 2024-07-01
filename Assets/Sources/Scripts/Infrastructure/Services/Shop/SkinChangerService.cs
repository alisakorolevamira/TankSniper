using System;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Players.Configs;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Decals;
using Sources.Scripts.Presentations.Views.Materials;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Shop
{
    public class SkinChangerService : ISkinChangerService
    {
        private readonly MaterialViewsConfig _materialViewsConfig;
        private readonly DecalViewsConfig _decalViewsConfig;
        
        private SkinChanger _skinChanger;

        public SkinChangerService(MaterialViewsConfig materialViewsConfig, DecalViewsConfig decalViewsConfig)
        {
            _materialViewsConfig = materialViewsConfig ? materialViewsConfig :
                throw new ArgumentNullException(nameof(materialViewsConfig));
            _decalViewsConfig = decalViewsConfig ? decalViewsConfig :
                throw new ArgumentNullException(nameof(decalViewsConfig));
        }
        
        public void Enable()
        {
            ChangeSkin(_skinChanger.CurrentSkin);
            ChangeMaterial(_skinChanger.CurrentMaterial);
            ChangeDecal(_skinChanger.CurrentDecal);
        }

        public void ChangeSkin(SkinType skinType) => 
            _skinChanger.ChangeSkin(skinType);

        public void ChangeMaterial(MaterialType materialType)
        {
            if (materialType == MaterialType.Default)
            {
                _skinChanger.SetDefaultMaterial();
                return;
            }
                
            MaterialView materialView = _materialViewsConfig.Materials.Find(material => material.Type == materialType);
            
            _skinChanger.ChangeMaterial(materialView);
        }

        public void ChangeDecal(DecalType decalType)
        {
            if (decalType == DecalType.Default)
            {
                _skinChanger.RemoveDecal();
                return;
            }

            DecalView decalView = _decalViewsConfig.Decals.Find(decal => decal.Type == decalType);
            
            _skinChanger.ChangeDecal(decalView);
        }
        
        public void Construct(SkinChanger skinChanger) => 
            _skinChanger = skinChanger ?? throw new ArgumentNullException(nameof(skinChanger));
    }
}