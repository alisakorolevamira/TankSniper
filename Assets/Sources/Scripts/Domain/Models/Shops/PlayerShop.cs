using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;

namespace Sources.Scripts.Domain.Models.Shops
{
    public class PlayerShop : IEntity
    {
        private PlayerShopData _data = new ();
        
        public PlayerShop(string id)
        {
            Id = id;

            PatternButtons = new List<ShopPatternButton>()
            {
                new (false, MaterialType.Green),
                new (false, MaterialType.Red),
                new (false, MaterialType.Grey),
                new (false, MaterialType.Sky),
                new (false, MaterialType.White),
            };
        }
        
        public string Id { get; }
        public List<ShopPatternButton> PatternButtons { get; private set; }
        
        public void Save()
        {
            _data.PatternButtons = PatternButtons;
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            PatternButtons = _data.PatternButtons;
        }
    }
}