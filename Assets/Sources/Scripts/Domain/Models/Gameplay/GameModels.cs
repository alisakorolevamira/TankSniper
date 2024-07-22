using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Domain.Models.Upgrades;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class GameModels
    {
        public GameModels(
            MainMenuAppearance mainMenu,
            CharacterHealth characterHealth,
            PlayerWallet playerWallet,
            PlayerAttacker playerAttacker,
            Volume volume,
            Level level,
            GameplayPlayer player,
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawner enemySpawner,
            Upgrader upgrader,
            SkinChanger skinChanger,
            StickmanChanger stickmanChanger,
            LevelAvailability levelAvailability,
            SavedLevel savedLevel)
        {
            CharacterHealth = characterHealth;
            //PlayerWallet = playerWallet;
            //PlayerAttacker = playerAttacker;
            Volume = volume;
            //Level = level;
            Player = player;
            KilledEnemiesCounter = killedEnemiesCounter;
            EnemySpawner = enemySpawner;
            SavedLevel = savedLevel;
            SkinChanger = skinChanger;
            StickmanChanger = stickmanChanger;
            //Upgrader = upgrader;
            LevelAvailability = levelAvailability;
            //MainMenu = mainMenu;
        }

        public CharacterHealth CharacterHealth { get; }
        //public PlayerWallet PlayerWallet { get; }
        //public PlayerAttacker PlayerAttacker { get; }
        public Volume Volume { get; }
        //public Level Level { get; }
        public GameplayPlayer Player { get; }
        public KilledEnemiesCounter KilledEnemiesCounter { get; }
        public EnemySpawner EnemySpawner { get; }
        public SavedLevel SavedLevel { get; }
        //public Upgrader Upgrader { get; }
        public SkinChanger SkinChanger { get; }
        public LevelAvailability LevelAvailability { get; }
        //public MainMenuAppearance MainMenu { get; }
        public StickmanChanger StickmanChanger { get; }
    }
}