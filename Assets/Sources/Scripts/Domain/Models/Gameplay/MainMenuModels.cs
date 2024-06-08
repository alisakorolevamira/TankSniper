using Sources.Scripts.Domain.Models.Settings;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class MainMenuModels
    {
        public MainMenuModels(
            Volume volume,
            Level firstLevel,
            Level secondLevel,
            Level thirdLevel,
            Level fourthLevel,
            Level fifthLevel,
            Level sixthLevel,
            LevelAvailability levelAvailability,
            GameData gameData,
            Tutorial tutorial,
            CurrentLevel currentLevel)
        {
            Volume = volume;
            FirstLevel = firstLevel;
            SecondLevel = secondLevel;
            ThirdLevel = thirdLevel;
            FourthLevel = fourthLevel;
            FifthLevel = fifthLevel;
            SixthLevel = sixthLevel;
            LevelAvailability = levelAvailability;
            GameData = gameData;
            Tutorial = tutorial;
            CurrentLevel = currentLevel;
        }

        public Volume Volume { get; }
        public Level FirstLevel { get; }
        public Level SecondLevel { get; }
        public Level ThirdLevel { get; }
        public Level FourthLevel { get; }
        public Level FifthLevel { get; }
        public Level SixthLevel { get; }
        public LevelAvailability LevelAvailability { get; }
        public GameData GameData { get; }
        public Tutorial Tutorial { get; }
        public CurrentLevel CurrentLevel { get; }
    }
}