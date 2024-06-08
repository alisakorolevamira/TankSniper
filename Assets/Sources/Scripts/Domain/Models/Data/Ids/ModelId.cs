using System;
using System.Collections.Generic;

namespace Sources.Scripts.Domain.Models.Data.Ids
{
    public class ModelId
    {
        public const string PlayerWallet = "PlayerWallet";
        public const string KillEnemyCounter = "KillEnemyCounter";
        public const string MainMenu = "MainMenu";
        public const string Volume = "Volume";
        public const string GameData = "GameData";
        public const string Tutorial = "Tutorial";
        public const string Gameplay = "Gameplay";
        public const string Gameplay2 = "GamePlay2";
        public const string Gameplay3 = "GamePlay3";
        public const string Gameplay4 = "GamePlay4";
        public const string Gameplay5 = "GamePlay5";
        public const string Gameplay6 = "GamePlay6";
        
        public static IReadOnlyList<string> DeletedModelsIds = new List<string>()
        {
            PlayerWallet,
            KillEnemyCounter,
        };
        
        public static IReadOnlyList<string> ModelsIds = new List<string>()
        {
            GameData,
            Gameplay,
            Gameplay2,
            Gameplay3,
            Gameplay4,
            Volume,
            PlayerWallet,
            KillEnemyCounter,
            Tutorial,
        };

        public static IReadOnlyDictionary<string, Type> DtoTypes = new Dictionary<string, Type>()
        {
            //[KillEnemyCounter] = typeof(KillEnemyCounterDto),
            [Tutorial] = typeof(TutorialDto),
            [GameData] = typeof(GameDataDto),
            [Volume] = typeof(VolumeDto),
            [Gameplay] = typeof(LevelDto),
            [Gameplay2] = typeof(LevelDto),
            [Gameplay3] = typeof(LevelDto),
            [Gameplay4] = typeof(LevelDto),
            [Gameplay5] = typeof(LevelDto),
            [Gameplay6] = typeof(LevelDto),
            //[PlayerWallet] = typeof(PlayerWalletDto),
        };
    }
}