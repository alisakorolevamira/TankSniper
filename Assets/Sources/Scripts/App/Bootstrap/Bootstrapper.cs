using Sources.Scripts.App.Core;
using Sources.Scripts.Infrastructure.Factories.App;
using UnityEngine;

namespace Sources.Scripts.App.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        private AppCore _appCore;

        private void Awake() =>
            _appCore = FindObjectOfType<AppCore>() ?? new AppCoreFactory().Create();
    }
}