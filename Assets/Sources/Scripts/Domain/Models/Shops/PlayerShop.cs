using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;

namespace Sources.Scripts.Domain.Models.Shops
{
    public class PlayerShop : IEntity
    {
        private PlayerShopData _data = new ();
        
        public PlayerShop(string id)
        {
            Id = id;

            AddPatterns();
            AddDecals();
        }
        
        public string Id { get; }
        public List<ShopPatternButton> PatternButtons { get; private set; }
        public List<ShopDecalButton> DecalButtons { get; private set; }
        
        public void Save()
        {
            _data.PatternButtons = PatternButtons;
            _data.DecalButtons = DecalButtons;
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            PatternButtons = _data.PatternButtons;
            DecalButtons = _data.DecalButtons;
        }

        private void AddPatterns()
        {
            PatternButtons = Enum.GetValues(typeof(MaterialType))
                .Cast<MaterialType>()
                .Select(material => new ShopPatternButton(false, material))
                .ToList();
        }

        private void AddDecals()
        {
            DecalButtons = Enum.GetValues(typeof(DecalType))
                .Cast<DecalType>()
                .Select(decal => new ShopDecalButton(false, decal))
                .ToList();
        }
    }
}