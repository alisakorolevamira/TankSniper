using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Upgrades;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class MainMenuModels
    {
        public MainMenuModels(
            Volume volume,
            //Level firstLevel,
            //Level secondLevel,
            //Level thirdLevel,
            //Level fourthLevel,
            //Level fifthLevel,
            //Level sixthLevel,
            GameLevels levels,
            LevelAvailability levelAvailability,
            GameData gameData,
            Tutorial tutorial,
            Player player,
            Upgrader upgrader,
            SkinChanger skinChanger,
            SavedLevel savedLevel,
            InventoryGrid grid)
        {
            Volume = volume;
            //FirstLevel = firstLevel;
            //SecondLevel = secondLevel;
            //ThirdLevel = thirdLevel;
            //FourthLevel = fourthLevel;
            //FifthLevel = fifthLevel;
            //SixthLevel = sixthLevel;
            Levels = levels;
            LevelAvailability = levelAvailability;
            GameData = gameData;
            Tutorial = tutorial;
            Player = player;
            Upgrader = upgrader;
            SkinChanger = skinChanger;
            SavedLevel = savedLevel;
            InventoryGrid = grid;
        }

        public Volume Volume { get; }
        //public Level FirstLevel { get; }
        //public Level SecondLevel { get; }
        //public Level ThirdLevel { get; }
        //public Level FourthLevel { get; }
        //public Level FifthLevel { get; }
        //public Level SixthLevel { get; }
        public GameLevels Levels { get; }
        public LevelAvailability LevelAvailability { get; }
        public GameData GameData { get; }
        public Tutorial Tutorial { get; }
        public Player Player { get; }
        public SavedLevel SavedLevel { get; }
        public Upgrader Upgrader { get; }
        public InventoryGrid InventoryGrid { get; }
        public SkinChanger SkinChanger { get; }
    }
}