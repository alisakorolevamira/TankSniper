using System;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.DomainInterfaces.Models.Shop;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;

namespace Sources.Scripts.Domain.Models.Shop
{
    public class ShopPatternButton : IShopPatternButton
    {
        public ShopPatternButton(string id, bool isBought, MaterialType materialType)
        {
            Id = id;
            IsBought = isBought;
            MaterialType = materialType;
        }
        
        public string Id { get; }
        public bool IsBought { get; private set; }
        public MaterialType MaterialType { get; private set; }
    }
}