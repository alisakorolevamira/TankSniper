using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class MainMenuAppearance : IEntity
    {
        private MainMenuData _data = new ();
        
        public MainMenuAppearance(string id)
        {
            Id = id;
            Index = 1;
        }
        
        public string Id { get; }
        public int Index { get; set; }
        
        public void Save()
        {
            _data.Id = Id;
            _data.Index = Index;
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            Index = _data.Index;
        }
    }
}