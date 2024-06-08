using System.Collections.Generic;

namespace Sources.Scripts.PresentationsInterfaces.Views.Gameplay
{
    public interface ILevelAvailabilityView
    {
        IReadOnlyList<ILevelView> Levels { get; }
    }
}