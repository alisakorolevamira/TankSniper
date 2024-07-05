using System.Collections.Generic;

namespace Sources.Scripts.Domain.Models.Gameplay
{
    public class LevelAvailability
    {
        public LevelAvailability(List<Level> levels, int index)
        {
            Levels = levels;
            Index = index;
        }

        public IReadOnlyList<Level> Levels { get; }
        public int Index { get; }
    }
}