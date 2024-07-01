using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class Tutorial : IEntity
    {
        private TutorialData _data = new ();
        
        public Tutorial(string id)
        {
            Id = id;
            HasCompleted = false;
        }

        public bool HasCompleted { get; private set; }
        public string Id { get; }

        public void Save()
        {
            _data.Id = Id;
            _data.HasCompleted = HasCompleted;
            
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            HasCompleted = _data.HasCompleted;
        }

        public void Complete() => 
            HasCompleted = true;
    }
}