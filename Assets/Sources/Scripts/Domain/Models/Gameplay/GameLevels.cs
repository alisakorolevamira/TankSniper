using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class GameLevels : IEntity
    {
        private LevelData _data = new ();
        
        public GameLevels(string id)
        {
            Id = id;
            Levels = new List<Level>()
            {
                new(LevelConst.FirstLevel, false),
                new(LevelConst.SecondLevel, false),
                new(LevelConst.ThirdLevel, false),
                new(LevelConst.FourthLevel, false),
                new(LevelConst.FifthLevel, false),
                new(LevelConst.SixthLevel, false),
            };
        }
        
        public string Id { get; }
        public List<Level> Levels { get; private set; }
        
        public void Save()
        {
            _data.Id = Id;
            _data.Levels = Levels;
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            Levels = _data.Levels;
        }
    }
}