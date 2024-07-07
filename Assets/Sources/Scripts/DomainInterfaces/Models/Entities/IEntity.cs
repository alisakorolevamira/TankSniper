namespace Sources.Scripts.DomainInterfaces.Models.Entities
{
    public interface IEntity
    {
        string Id { get; }
        void Save();
        void Load();
    }
}