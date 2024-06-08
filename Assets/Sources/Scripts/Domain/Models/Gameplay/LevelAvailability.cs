using System.Collections.Generic;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class LevelAvailability
    {
        public LevelAvailability(List<Level> levels)
        {
            Levels = levels;
        }

        public IReadOnlyList<Level> Levels { get; }
    }
}