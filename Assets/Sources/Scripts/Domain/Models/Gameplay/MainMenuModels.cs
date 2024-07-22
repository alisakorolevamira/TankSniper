using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Domain.Models.Upgrades;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class MainMenuModels
    {
        public MainMenuModels(
            MainMenuAppearance mainMenuAppearance,
            Volume volume,
            GameLevels levels,
            LevelAvailability levelAvailability,
            GameData gameData,
            Tutorial tutorial,
            Player player,
            Upgrader upgrader,
            SkinChanger skinChanger,
            StickmanChanger stickmanChanger,
            SavedLevel savedLevel,
            InventoryGrid grid,
            PlayerShop shop)
        {
            MainMenuAppearance = mainMenuAppearance;
            Volume = volume;
            //Levels = levels;
            LevelAvailability = levelAvailability;
            //GameData = gameData;
            Tutorial = tutorial;
            Player = player;
            Upgrader = upgrader;
            SkinChanger = skinChanger;
            StickmanChanger = stickmanChanger;
            SavedLevel = savedLevel;
            InventoryGrid = grid;
            Shop = shop;
        }

        public Volume Volume { get; }
        //public GameLevels Levels { get; }
        public LevelAvailability LevelAvailability { get; }
        //public GameData GameData { get; }
        public Tutorial Tutorial { get; }
        public Player Player { get; }
        public SavedLevel SavedLevel { get; }
        public Upgrader Upgrader { get; }
        public InventoryGrid InventoryGrid { get; }
        public SkinChanger SkinChanger { get; }
        public PlayerShop Shop { get; }
        public MainMenuAppearance MainMenuAppearance { get; }
        public StickmanChanger StickmanChanger { get; }
    }
}