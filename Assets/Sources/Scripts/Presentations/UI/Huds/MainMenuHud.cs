using System.Collections.Generic;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.Presentations.Views.Shop;
using Sources.Scripts.UIFramework.Presentations.AudioSources;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using UnityEngine;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public class MainMenuHud : View, IHud
    {
        [Header("Audio")]
        [SerializeField] private List<UIAudioSource> _uiAudioSources;
        [SerializeField] private VolumeView _volumeView;
        
        [Header("Levels")]
        [SerializeField] private LevelAvailabilityView _levelAvailabilityView;
        
        [Header("Wallet")]
        [SerializeField] private List<WalletUI> _walletsUI;
        
        [Header("Inventory")]
        [SerializeField] private InventoryGridView _gridView;
        
        public IReadOnlyList<IUIAudioSource> UIAudioSources => _uiAudioSources;
        public LevelAvailabilityView LevelAvailabilityView => _levelAvailabilityView;
        public VolumeView VolumeView => _volumeView;
        public IReadOnlyList<WalletUI> WalletsUI => _walletsUI;
        public InventoryGridView InventoryGridView => _gridView;
    }
}