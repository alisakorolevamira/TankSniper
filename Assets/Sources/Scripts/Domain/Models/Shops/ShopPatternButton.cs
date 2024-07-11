using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;

namespace Sources.Scripts.Domain.Models.Shops
{
    public class ShopPatternButton
    {
        public ShopPatternButton(bool isBought, MaterialType materialType)
        {
            IsBought = isBought;
            MaterialType = materialType;
        }
        
        public bool IsBought { get; set; }
        public MaterialType MaterialType { get; }
    }
}