using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class SavedLevel : IEntity
    {
        private SavedLevelData _data = new ();
        
        public SavedLevel(string id)
        {
            Id = id;
            CurrentLevelId = LevelConst.FirstLevel;
        }
        
        public string Id { get; }
        public string CurrentLevelId { get; set; }
        
        public void Save()
        {
            _data.Id = Id;
            _data.SavedLevelId = CurrentLevelId;
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            CurrentLevelId = _data.SavedLevelId;
        }

        public void Clear() => 
            CurrentLevelId = LevelConst.FirstLevel;
    }
}