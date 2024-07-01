using System;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.LoadServices
{
    public class LoadService : ILoadService
    {
        private readonly IEntityRepository _entityRepository;

        public LoadService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }
        
        public IEntity Load(string id)
        {
            IEntity entity = ModelId.Entities[id];
            
            entity.Load();
            _entityRepository.Add(entity);
            
            return entity;
        }

        public void Save(IEntity entity) => 
            entity.Save();

        public void Save(string id)
        {
            IEntity entity = _entityRepository.Get(id);
           
           entity.Save();
        }

        public void LoadAll()
        {
            foreach (string id in ModelId.ModelsIds)
            {
                IEntity entity = ModelId.Entities[id];
                
                entity.Load();
                _entityRepository.Add(entity);
            }
        }

        public void SaveAll()
        {
            foreach (IEntity entity in _entityRepository.Entities.Values) 
                entity.Save();
        }

        public bool HasKey(string id) =>
            PlayerPrefs.HasKey(id);
    }
}