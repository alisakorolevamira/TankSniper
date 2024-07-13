using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Stickman;

namespace Sources.Scripts.PresentationsInterfaces.Views.Stickman
{
    public interface IStickmanChangerView
    {
        IReadOnlyDictionary<StickmanType, StickmanView> Stickmen { get; }
        StickmanView CurrentStickmanView { get; }

        void SetCurrentStickman(StickmanType stickmanType);
    }
}