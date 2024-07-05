using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Data.Ids
{
    public class ModelId
    {
        public const string GameData = "GameData";
        public const string SavedLevel = "SavedLevel";
        public const string Volume = "Volume";
        public const string PlayerWallet = "PlayerWallet";
        public const string MainMenu = "MainMenu";
        public const string Tutorial = "Tutorial";
        public const string Upgrader = "Upgrader";
        public const string SkinChanger = "SkinChanger";
        public const string GameLevels = "GameLevels";
        public const string InventoryGrid = "InventoryGrid";
        public const string PlayerShop = "PlayerShop";
        public const string MainMenuAppearance = "MainMenuAppearance";
        
        
        public static IReadOnlyList<string> ModelsIds = new List<string>()
        {
            GameData,
            SavedLevel,
            Volume,
            PlayerWallet,
            Tutorial,
            Upgrader,
            SkinChanger,
            GameLevels,
            InventoryGrid,
            PlayerShop,
            MainMenuAppearance,
        };

        public static IReadOnlyDictionary<string, Type> DtoTypes = new Dictionary<string, Type>()
        {
            [GameData] = typeof(GameDataData),
            [SavedLevel] = typeof(SavedLevelData),
            [Volume] = typeof(VolumeData),
            [PlayerWallet] = typeof(PlayerWalletData),
            [Tutorial] = typeof(TutorialData),
            [Upgrader] = typeof(UpgradeData),
            [SkinChanger] = typeof(SkinChangerData),
            [GameLevels] = typeof(LevelData),
            [InventoryGrid] = typeof(InventoryGridData),
            [MainMenuAppearance] = typeof(MainMenuData)
        };

        public static IReadOnlyDictionary<string, IEntity> Entities = new Dictionary<string, IEntity>()
        {
            [GameData] = new GameData(GameData),
            [SavedLevel] = new SavedLevel(SavedLevel),
            [Volume] = new Volume(Volume),
            [PlayerWallet] = new PlayerWallet(PlayerWallet),
            [Tutorial] = new Tutorial(Tutorial),
            [Upgrader] = new Upgrader(Upgrader),
            [SkinChanger] = new SkinChanger(SkinChanger),
            [GameLevels] = new GameLevels(GameLevels),
            [InventoryGrid] = new InventoryGrid(InventoryGrid),
            [PlayerShop] = new PlayerShop(PlayerShop),
            [MainMenuAppearance] = new MainMenuAppearance(MainMenuAppearance)
        };
    }
}