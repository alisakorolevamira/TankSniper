using Sources.Scripts.Domain.Models.Common;
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
            CharacterHealth characterHealth,
            PlayerWallet playerWallet,
            PlayerAttacker playerAttacker,
            Volume volume,
            Level level,
            Player player,
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawner enemySpawner,
            SavedLevel savedLevel)
        {
            CharacterHealth = characterHealth;
            PlayerWallet = playerWallet;
            PlayerAttacker = playerAttacker;
            Volume = volume;
            Level = level;
            Player = player;
            KilledEnemiesCounter = killedEnemiesCounter;
            EnemySpawner = enemySpawner;
            SavedLevel = savedLevel;
        }

        public CharacterHealth CharacterHealth { get; }
        public PlayerWallet PlayerWallet { get; }
        public PlayerAttacker PlayerAttacker { get; }
        public Volume Volume { get; }
        public Level Level { get; }
        public Player Player { get; }
        public KilledEnemiesCounter KilledEnemiesCounter { get; }
        public EnemySpawner EnemySpawner { get; }
        public SavedLevel SavedLevel { get; }
    }
}