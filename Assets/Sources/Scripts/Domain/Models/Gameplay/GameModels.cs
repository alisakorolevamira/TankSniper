using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Upgrades;
using UnityEngine.TextCore.Text;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class GameModels
    {
        public GameModels(
            //CharacterHealth characterHealth,
            PlayerWallet playerWallet,
            Volume volume,
            Level level,
            //Character character,
            //KillEnemyCounter killEnemyCounter,
            //EnemySpawner enemySpawner,
            CurrentLevel currentLevel)
            //UpgradeController upgradeController)
        {
            //CharacterHealth = characterHealth;
            PlayerWallet = playerWallet;
            Volume = volume;
            Level = level;
            //Character = character;
            //KillEnemyCounter = killEnemyCounter;
            //EnemySpawner = enemySpawner;
            CurrentLevel = currentLevel;
        }

        //public CharacterHealth CharacterHealth { get; }
        public PlayerWallet PlayerWallet { get; }
        public Volume Volume { get; }
        public Level Level { get; }
        public Character Character { get; }
        //public KillEnemyCounter KillEnemyCounter { get; }
        //public EnemySpawner EnemySpawner { get; }
        public CurrentLevel CurrentLevel { get; }
    }
}