using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Shop
{
    public interface ISkinChangerService
    {
        void ChangeSkin(SkinType skinType);
        void ChangeMaterial(MaterialType materialType);
        void ChangeDecal(Sprite decal);
        void Construct(SkinChanger skinChanger);
    }
}