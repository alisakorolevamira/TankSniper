using System;
using Sources.Scripts.DomainInterfaces.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.InfrastructureInterfaces.Services.LoadServices.Collectors
{
    public interface IMapperCollector
    {
        Func<IEntity, IDto> GetToDtoMapper(Type type);
        Func<IDto, IEntity> GetToModelMapper(Type type);
    }
}