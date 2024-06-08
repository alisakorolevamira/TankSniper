using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.Domain.Models.Upgrades;
using UnityEngine.TextCore.Text;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class GameModels
    {
        public GameModels(
            PlayerHealth playerHealth,
            PlayerWallet playerWallet,
            Volume volume,
            Level level,
            //Character character,
            KilledEnemiesCounter killedEnemiesCounter,
            //EnemySpawner enemySpawner,
            CurrentLevel currentLevel)
            //UpgradeController upgradeController)
        {
            PlayerHealth = playerHealth;
            PlayerWallet = playerWallet;
            Volume = volume;
            Level = level;
            //Character = character;
            KilledEnemiesCounter = killedEnemiesCounter;
            //EnemySpawner = enemySpawner;
            CurrentLevel = currentLevel;
        }

        public PlayerHealth PlayerHealth { get; }
        public PlayerWallet PlayerWallet { get; }
        public Volume Volume { get; }
        public Level Level { get; }
        //public Character Character { get; }
        public KilledEnemiesCounter KilledEnemiesCounter { get; }
        //public EnemySpawner EnemySpawner { get; }
        public CurrentLevel CurrentLevel { get; }
    }
}