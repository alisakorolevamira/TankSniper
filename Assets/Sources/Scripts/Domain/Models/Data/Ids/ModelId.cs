using System;
using System.Collections.Generic;

namespace Sources.Scripts.Domain.Models.Data.Ids
{
    public class ModelId
    {
        public const string PlayerWallet = "PlayerWallet";
        public const string MainMenu = "MainMenu";
        public const string CurrentLevel = "CurrentLevel";
        public const string Volume = "Volume";
        public const string GameData = "GameData";
        public const string Tutorial = "Tutorial";
        public const string FirstLevel = "FirstLevel";
        public const string SecondLevel = "SecondLevel";
        public const string ThirdLevel = "ThirdLevel";
        public const string FourthLevel = "FourthLevel";
        public const string FifthLevel = "FifthLevel";
        public const string SixthLevel = "SixthLevel";
        
        public static IReadOnlyList<string> DeletedModelsIds = new List<string>()
        {
            PlayerWallet
        };
        
        public static IReadOnlyList<string> ModelsIds = new List<string>()
        {
            GameData,
            CurrentLevel,
            FirstLevel,
            SecondLevel,
            ThirdLevel,
            FourthLevel,
            FifthLevel,
            SixthLevel,
            Volume,
            PlayerWallet,
            Tutorial,
        };

        public static IReadOnlyDictionary<string, Type> DtoTypes = new Dictionary<string, Type>()
        {
            [Tutorial] = typeof(TutorialDto),
            [GameData] = typeof(GameDataDto),
            [CurrentLevel] = typeof(CurrentLevelDto),
            [Volume] = typeof(VolumeDto),
            [FirstLevel] = typeof(LevelDto),
            [SecondLevel] = typeof(LevelDto),
            [ThirdLevel] = typeof(LevelDto),
            [FourthLevel] = typeof(LevelDto),
            [FifthLevel] = typeof(LevelDto),
            [SixthLevel] = typeof(LevelDto),
            [PlayerWallet] = typeof(PlayerWalletDto),
        };
    }
}