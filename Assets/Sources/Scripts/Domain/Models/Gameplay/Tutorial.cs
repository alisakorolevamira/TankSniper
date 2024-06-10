﻿using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class Tutorial : IEntity
    {
        public Tutorial(TutorialDto tutorialDto)
            : this(tutorialDto.Id, tutorialDto.HasCompleted)
        {
        }

        public Tutorial()
            : this(ModelId.Tutorial, false)
        {
        }

        private Tutorial(string id, bool hasCompleted)
        {
            Id = id;
            HasCompleted = hasCompleted;
        }

        public bool HasCompleted { get; set; }
        public string Id { get; }
        public Type Type => GetType();
    }
}