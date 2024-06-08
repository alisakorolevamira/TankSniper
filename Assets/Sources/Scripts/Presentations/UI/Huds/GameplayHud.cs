using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.UIFramework.Presentations.Views;
using UnityEngine;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public class GameplayHud : View, IHud
    {
        [SerializeField] private UICollector _uiCollector;
        [SerializeField] private CinemachineCameraView _cinemachineCameraView;
        [SerializeField] private PlayerWalletView _playerWalletViews;
        [SerializeField] private KilledEnemiesCounterView _killedEnemiesCounterView;
        [SerializeField] private HealthBarUI _playerHealthBarUI;
        [SerializeField] private VolumeView _volumeView;
        
        public UICollector UICollector => _uiCollector;
        
        public CinemachineCameraView CinemachineCameraView => _cinemachineCameraView;
        
        public PlayerWalletView PlayerWalletViews => _playerWalletViews;

        public KilledEnemiesCounterView KilledEnemiesCounterView => _killedEnemiesCounterView;
        
        public HealthBarUI PlayerHealthBarUI => _playerHealthBarUI;
        
        public VolumeView VolumeView => _volumeView;
    }
}