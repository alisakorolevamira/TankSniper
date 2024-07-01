using System;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;

namespace Sources.Scripts.Infrastructure.Services.Tutorials
{
    public class TutorialService : ITutorialService
    {
        private readonly ILoadService _loadService;
        private Tutorial _tutorial;
        
        private SignalReceiver _signalReceiver;
        private SignalStream _signalStream;

        public TutorialService(ILoadService loadService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public bool IsCompleted => _tutorial.HasCompleted;

        public void Enable()
        {
            if (_tutorial.HasCompleted)
                return;
            
            Signal.Send(StreamId.MainMenu.ShowAddTankTutorial);
        }
        public void Complete()
        {
            _tutorial.Complete();
            _loadService.Save(_tutorial);
        }

        public void Construct(Tutorial tutorial) => 
            _tutorial = tutorial ?? throw new ArgumentNullException(nameof(tutorial));

    }
}