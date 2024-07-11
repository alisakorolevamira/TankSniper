using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;

namespace Sources.Scripts.Domain.Models.Shops
{
    public class ShopDecalButton
    {
        public ShopDecalButton(bool isBought, DecalType decalType)
        {
            IsBought = isBought;
            DecalType = decalType;
        }
        
        public bool IsBought { get; set; }
        public DecalType DecalType { get; }
    }
}