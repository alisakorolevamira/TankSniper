﻿using System;
using System.Collections.Generic;

namespace Sources.Scripts.Domain.Models.Data.Ids
{
    public class ModelId
    {
        public const string PlayerWallet = "PlayerWallet";
        public const string MainMenu = "MainMenu";
        public const string SavedLevel = "SavedLevel";
        public const string Volume = "Volume";
        public const string GameData = "GameData";
        public const string Tutorial = "Tutorial";
        public const string FirstLevel = "FirstLevel";
        public const string SecondLevel = "SecondLevel";
        public const string ThirdLevel = "ThirdLevel";
        public const string FourthLevel = "FourthLevel";
        public const string FifthLevel = "FifthLevel";
        public const string SixthLevel = "SixthLevel";
        public const string FirstSlot = "FirstSlot";
        public const string SecondSlot = "SecondSlot";
        public const string ThirdSlot = "ThirdSlot";
        public const string FourthSlot = "FourthSlot";
        public const string FifthSlot = "FifthSlot";
        public const string SixthSlot = "SixthSlot";
        public const string SeventhSlot = "SeventhSlot";
        public const string EighthSlot = "EighthSlot";
        public const string NinthSlot = "NinthSlot";
        
        
        public static IReadOnlyList<string> DeletedModelsIds = new List<string>()
        {
            PlayerWallet,
        };
        
        public static IReadOnlyList<string> ModelsIds = new List<string>()
        {
            GameData,
            SavedLevel,
            FirstLevel,
            SecondLevel,
            ThirdLevel,
            FourthLevel,
            FifthLevel,
            SixthLevel,
            Volume,
            PlayerWallet,
            Tutorial,
            GameData,
            Volume,
            PlayerWallet,
            Tutorial,
        };

        public static IReadOnlyDictionary<string, Type> DtoTypes = new Dictionary<string, Type>()
        {
            [Tutorial] = typeof(TutorialDto),
            [GameData] = typeof(GameDataDto),
            [SavedLevel] = typeof(SavedLevelDto),
            [Volume] = typeof(VolumeDto),
            [FirstLevel] = typeof(LevelDto),
            [SecondLevel] = typeof(LevelDto),
            [ThirdLevel] = typeof(LevelDto),
            [FourthLevel] = typeof(LevelDto),
            [FifthLevel] = typeof(LevelDto),
            [SixthLevel] = typeof(LevelDto),
            [PlayerWallet] = typeof(PlayerWalletDto),
            [FirstSlot] = typeof(InventorySlotDto),
            [SecondSlot] = typeof(InventorySlotDto),
            [ThirdSlot] = typeof(InventorySlotDto),
            [FourthSlot] = typeof(InventorySlotDto),
            [FifthSlot] = typeof(InventorySlotDto),
            [SixthSlot] = typeof(InventorySlotDto),
            [SeventhSlot] = typeof(InventorySlotDto),
            [EighthSlot] = typeof(InventorySlotDto),
            [NinthSlot] = typeof(InventorySlotDto),
        };
    }
}