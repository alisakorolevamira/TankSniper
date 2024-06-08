using System;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.DomainInterfaces.Models.Upgrades
{
    public interface IUpgrader : IEntity
    {
        event Action LevelChanged;

        int CurrentLevel { get; }
        int MaxLevel { get; }
    }
}