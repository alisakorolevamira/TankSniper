﻿using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.InfrastructureInterfaces.Services.LoadServices
{
    public interface ILoadService
    {
        IEntity Load(string id);
        void Save(IEntity entity);
        void Save(string id);
        void LoadAll();
        void SaveAll();
        void Clear(IEntity entity);
        void Clear(string id);
        void ClearAll();
        bool HasKey(string id);
    }
}