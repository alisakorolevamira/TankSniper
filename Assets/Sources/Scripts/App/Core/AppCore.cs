using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneServices;
using UnityEngine;

namespace Sources.Scripts.App.Core
{
    public class AppCore : MonoBehaviour
    {
        private ISceneService _sceneService;

        private void Awake() =>
            DontDestroyOnLoad(this);

        private async void Start()
        {
            try
            {
                await _sceneService.ChangeSceneAsync(
                    //ModelId.MainMenu,
                    LevelConst.TenthLevel,
                    new ScenePayload(LevelConst.TenthLevel, false, false));
            }
            catch(ArgumentNullException)
            {
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void Update() =>
            _sceneService?.Update(Time.deltaTime);

        private void LateUpdate() =>
            _sceneService?.UpdateLate(Time.deltaTime);

        private void FixedUpdate() =>
            _sceneService?.UpdateFixed(Time.fixedDeltaTime);

        public void Construct(ISceneService sceneService) =>
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
    }
}