using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class GameData : IEntity
    {
        public GameData(string id, bool wasLaunched)
        {
            Id = id;
            WasLaunched = wasLaunched;
        }

        public string Id { get; }
        public Type Type => GetType();
        public bool WasLaunched { get; private set; }
    }
}