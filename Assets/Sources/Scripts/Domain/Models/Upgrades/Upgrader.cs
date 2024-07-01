using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Upgrades
{
    public class Upgrader : IEntity
    {
        private UpgradeData _data = new ();
        
        public Upgrader(string id)
        {
            Id = id;
            CurrentLevel = PlayerConst.DefaultLevel;
        }

        public event Action LevelChanged;

        public string Id { get; }
        public int CurrentLevel { get; private set; }

        public void Upgrade()
        {
            if (CurrentLevel >= PlayerConst.MaxLevel)
                return;

            CurrentLevel++;
            LevelChanged?.Invoke();
        }

        public void Save()
        {
            _data.CurrentLevel = CurrentLevel;
            _data.Id = Id;
            
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            CurrentLevel = _data.CurrentLevel;
        }
    }
}