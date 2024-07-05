using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class GameData : IEntity
    {
        private GameDataData gameDataData = new ();
        private bool _wasLaunched;
        
        public GameData(string id)
        {
            Id = id;
            _wasLaunched = true;
        }

        public string Id { get; }

        public void Save()
        {
            gameDataData.Id = Id;
            gameDataData.WasLaunched = _wasLaunched;
            gameDataData.Save(Id);
        }

        public void Load()
        {
            gameDataData = gameDataData.Load(Id);
            _wasLaunched = gameDataData.WasLaunched;
        }
    }
}