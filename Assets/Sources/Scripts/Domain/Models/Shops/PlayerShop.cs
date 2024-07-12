using System.Collections.Generic;
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
            PatternButtons = new List<ShopPatternButton>
            {
                new (false, MaterialType.Green),
                new (false, MaterialType.Red),
                new (false, MaterialType.Grey),
                new (false, MaterialType.Sky),
                new (false, MaterialType.White),
                new (false, MaterialType.Pink),
                new (false, MaterialType.Yellow),
                new (false, MaterialType.Purple),
                new (false, MaterialType.PurpleDark),
                new (false, MaterialType.Blue),
                new (false, MaterialType.BlueDark),
                new (false, MaterialType.Brown),
                new (false, MaterialType.Orange),
                new (false, MaterialType.BrightGreen),
                new (false, MaterialType.BrightPink),
            };
        }

        private void AddDecals()
        {
            DecalButtons = new List<ShopDecalButton>
            {
                new (false, DecalType.Cat),
                new (false, DecalType.Bat),
                new (false, DecalType.Scull),
                new (false, DecalType.Bang),
                new (false, DecalType.Duck),
                new (false, DecalType.Ghost),
                new (false, DecalType.Bomb),
                new (false, DecalType.NuclearBomb),
                new (false, DecalType.Rabbit),
                new (false, DecalType.Shark),
                new (false, DecalType.Unicorn),
                new (false, DecalType.Wolf),
                new (false, DecalType.Wednesday),
                new (false, DecalType.Swords),
                new (false, DecalType.Men),
            };
        }
    }
}