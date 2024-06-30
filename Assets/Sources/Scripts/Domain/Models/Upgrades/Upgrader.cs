using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.DomainInterfaces.Models.Upgrades;

namespace Sources.Scripts.Domain.Models.Upgrades
{
    public class Upgrader : IUpgrader
    {
        public Upgrader(
            int currentLevel,
            string id)
        {
            CurrentLevel = currentLevel;
            Id = id;
        }

        public event Action LevelChanged;

        public string Id { get; }
        public Type Type => GetType();
        public int CurrentLevel { get; private set; }
        public int MaxLevel { get; } = PlayerConst.MaxLevel;

        public void Upgrade()
        {
            if (CurrentLevel >= MaxLevel)
                return;

            CurrentLevel++;
            LevelChanged?.Invoke();
        }
    }
}