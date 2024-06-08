using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.DomainInterfaces.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Services.Saves
{
    public class SaveService : ISaveService
    {
        private readonly ILoadService _loadService;
        private readonly IFormService _formService; 
        private readonly TimeSpan _showedFormDelay = TimeSpan.FromSeconds(5f); //вынести в константу
        
        private CancellationTokenSource _cancellationTokenSource;

        public SaveService(
            ILoadService loadService,
            IFormService formService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enter(object payload = null)
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Exit()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}