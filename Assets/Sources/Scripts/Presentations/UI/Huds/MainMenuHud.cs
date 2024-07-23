using System.Collections.Generic;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.Presentations.Views.MainMenu;
using Sources.Scripts.Presentations.Views.Music;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Players.Skins;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.Presentations.Views.Shops;
using Sources.Scripts.Presentations.Views.Stickman;
using Sources.Scripts.UIFramework.Presentations.AudioSources;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using UnityEngine;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public class MainMenuHud : View, IHud
    {
        [Header("Audio")]
        [SerializeField] private UIAudioSource _uiAudioSource;
        [SerializeField] private VolumeView _volumeView;
        [SerializeField] private BackgroundMusicView _backgroundMusicView;
        
        [Header("Levels")]
        [SerializeField] private List<LevelAvailabilityView> _levelAvailabilityViews;
        
        [Header("Wallet")]
        [SerializeField] private List<WalletUI> _walletsUI;
        
        [Header("Inventory")]
        [SerializeField] private InventoryGridView _gridView;
        [SerializeField] private InventoryTankButtonView _addTankButtonView;

        [Header("Player")]
        [SerializeField] private List<SkinChangerView> _skinChangerViews;
        [SerializeField] private List<StickmanChangerView> _stickmanChangerViews;

        [Header("Shop")]
        [SerializeField] private ShopView _shopView;
        
        [Header("Appearance")]
        [SerializeField] private MainMenuView _mainMenuView;
        
        public IUIAudioSource UIAudioSource => _uiAudioSource;
        public IReadOnlyList<LevelAvailabilityView> LevelAvailabilityViews => _levelAvailabilityViews;
        public VolumeView VolumeView => _volumeView;
        public BackgroundMusicView BackgroundMusicView => _backgroundMusicView;
        public IReadOnlyList<WalletUI> WalletsUI => _walletsUI;
        public InventoryGridView InventoryGridView => _gridView;
        public IReadOnlyList<SkinChangerView> SkinChangerViews => _skinChangerViews;
        public IReadOnlyList<StickmanChangerView> StickmanChangerViews => _stickmanChangerViews;
        public ShopView ShopView => _shopView;
        public InventoryTankButtonView AddTankButtonView => _addTankButtonView;
        public MainMenuView MainMenuView => _mainMenuView;
    }
}