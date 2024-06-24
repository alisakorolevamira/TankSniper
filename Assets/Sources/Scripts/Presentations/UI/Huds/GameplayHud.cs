using System.Collections.Generic;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.Presentations.Views.Weapons;
using Sources.Scripts.UIFramework.Presentations.AudioSources;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using UnityEngine;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public class GameplayHud : View, IHud
    {
        [Header("Audio")]
        [SerializeField] private List<UIAudioSource> _uiAudioSources;
        [SerializeField] private VolumeView _volumeView;
        
        [Header("Camera")]
        [SerializeField] private CameraView cameraView;
        
        [Header("Player")]
        [SerializeField] private List<WalletUI> _walletsUI;
        [SerializeField] private List<HealthBarUI> _playerHealthBars;
        [SerializeField] private AttackerUIView _attackerUIView;
        
        [Header("Enemy")]
        [SerializeField] private List<KilledEnemiesCounterView> _killedEnemiesCounterViews;

        [Header("Weapon")]
        [SerializeField] private ReloadWeaponView _reloadWeaponView;
        [SerializeField] private RectTransform _shootZone;
        
        public IReadOnlyList<IUIAudioSource> UIAudioSources => _uiAudioSources;
        
        public CameraView CameraView => cameraView;
        public RectTransform ShootZone => _shootZone;
        
        public IReadOnlyList<WalletUI> WalletsUI => _walletsUI;

        public IReadOnlyList<KilledEnemiesCounterView> KilledEnemiesCounterViews => _killedEnemiesCounterViews;
        
        public IReadOnlyList<HealthBarUI> PlayerHealthBarUIs => _playerHealthBars;
        
        public VolumeView VolumeView => _volumeView;
        public AttackerUIView AttackerUIView => _attackerUIView;
        public ReloadWeaponView ReloadWeaponView => _reloadWeaponView;
    }
}