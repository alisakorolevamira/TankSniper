using System.Collections.Generic;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.UIFramework.Presentations.Views;
using UnityEngine;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public class MainMenuHud : View, IHud
    {
        [SerializeField] private UICollector _uICollector;
        [SerializeField] private LevelAvailabilityView _levelAvailabilityView;
        [SerializeField] private VolumeView _volumeView;
        [SerializeField] private List<WalletUI> _walletsUI;
        [SerializeField] private InventoryGridView _gridView;
        
        public UICollector UICollector => _uICollector;
        public LevelAvailabilityView LevelAvailabilityView => _levelAvailabilityView;
        public VolumeView VolumeView => _volumeView;
        public IReadOnlyList<WalletUI> WalletsUI => _walletsUI;
        public InventoryGridView InventoryGridView => _gridView;
    }
}