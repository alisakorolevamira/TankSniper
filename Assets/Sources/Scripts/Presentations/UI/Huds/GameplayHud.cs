using System.Collections.Generic;
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
        [SerializeField] private CameraView cameraView;
        [SerializeField] private WalletUI _walletUI;
        [SerializeField] private List<KilledEnemiesCounterView> _killedEnemiesCounterViews;
        [SerializeField] private List<HealthBarUI> _playerHealthBars;
        [SerializeField] private VolumeView _volumeView;
        
        public UICollector UICollector => _uiCollector;
        
        public CameraView CameraView => cameraView;
        
        public WalletUI WalletUI => _walletUI;

        public IReadOnlyList<KilledEnemiesCounterView> KilledEnemiesCounterViews => _killedEnemiesCounterViews;
        
        public IReadOnlyList<HealthBarUI> PlayerHealthBarUIs => _playerHealthBars;
        
        public VolumeView VolumeView => _volumeView;
    }
}