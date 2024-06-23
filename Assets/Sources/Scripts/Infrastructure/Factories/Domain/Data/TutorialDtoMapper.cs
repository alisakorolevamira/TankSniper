﻿using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class TutorialDtoMapper : ITutorialDtoMapper
    {
        public TutorialDto MapModelToDto(Tutorial tutorial)
        {
            return new TutorialDto()
            {
                Id = tutorial.Id,
                HasCompleted = tutorial.HasCompleted,
            };
        }

        public Tutorial MapDtoToModel(TutorialDto tutorialDto) =>
            new(tutorialDto.Id, tutorialDto.HasCompleted);
    }
}