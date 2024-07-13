using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.Presentations.Views.Stickman;

namespace Sources.Scripts.Domain.Models.Stickman
{
    public class StickmanChanger : IEntity
    {
        private StickmanChangerData _data = new ();
        
        public StickmanChanger(string id)
        {
            Id = id;
            CurrentStickman = StickmanType.Default;
        }

        public StickmanType CurrentStickman { get; private set; }
        public string Id { get; }
        
        public event Action CurrentStickmanChanged;
        
        public void Save()
        {
            _data.Id = Id;
            _data.CurrentStickmanType = CurrentStickman;
            
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            CurrentStickman = _data.CurrentStickmanType;
        }

        public void ChangeStickman(StickmanType stickmanType)
        {
            CurrentStickman = stickmanType;
            CurrentStickmanChanged?.Invoke();
        }
    }
}