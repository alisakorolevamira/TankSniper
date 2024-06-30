using System;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;

namespace Sources.Scripts.DomainInterfaces.Models.Upgrades
{
    public interface IUpgrader : IEntity
    {
        event Action LevelChanged;

        int CurrentLevel { get; }
        int MaxLevel { get; }
    }
}