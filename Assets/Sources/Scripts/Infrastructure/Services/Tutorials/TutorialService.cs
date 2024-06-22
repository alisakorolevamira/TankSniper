using System;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Tutorials
{
    public class TutorialService : ITutorialService
    {
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;
        private Tutorial _tutorial;
        private SavedLevel _savedLevel;

        public TutorialService(
            IFormService formService,
            ILoadService loadService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public void Enable()
        {
            if (_tutorial.HasCompleted)
                return;

            //if (_savedLevel.CurrentLevelId != ModelId.MainMenu)
            //    return;

            _formService.Show(FormId.AddTankTutorial);
        }

        public void Construct(Tutorial tutorial, SavedLevel savedLevel)
        {
            _tutorial = tutorial ?? throw new ArgumentNullException(nameof(tutorial));
            _savedLevel = savedLevel ?? throw new ArgumentNullException(nameof(savedLevel));
        }

        public void Complete()
        {
            _tutorial.HasCompleted = true;
            _loadService.Save(_tutorial);
        }
    }
}