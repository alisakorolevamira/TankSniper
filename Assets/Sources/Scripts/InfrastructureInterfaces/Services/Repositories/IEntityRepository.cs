using System.Collections.Generic;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Repositories
{
    public interface IEntityRepository
    {
        IReadOnlyDictionary<string, IEntity> Entities { get; }
        
        void Add(IEntity entity);
        IEntity Get(string id);
        T Get<T>(string id) 
            where T : class, IEntity;
        void Release();
    }
}