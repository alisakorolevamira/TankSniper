using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.UIFramework.Presentations.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public class GameplayHud : View, IHud
    {
        [SerializeField] private UICollector _uiCollector;
        [FormerlySerializedAs("_cinemachineCameraView")] [SerializeField] private CameraView cameraView;
        [SerializeField] private WalletUI _walletUI;
        [SerializeField] private KilledEnemiesCounterView [] _killedEnemiesCounterViews;
        [SerializeField] private HealthBarUI [] _playerHealthBarUIs;
        [SerializeField] private VolumeView _volumeView;
        
        public UICollector UICollector => _uiCollector;
        
        public CameraView CameraView => cameraView;
        
        public WalletUI WalletUI => _walletUI;

        public KilledEnemiesCounterView [] KilledEnemiesCounterViews => _killedEnemiesCounterViews;
        
        public HealthBarUI [] PlayerHealthBarUIs => _playerHealthBarUIs;
        
        public VolumeView VolumeView => _volumeView;
    }
}