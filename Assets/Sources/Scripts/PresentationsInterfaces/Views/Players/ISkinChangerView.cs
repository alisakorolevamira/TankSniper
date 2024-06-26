using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Players.SkinTypes;

namespace Sources.Scripts.PresentationsInterfaces.Views.Players
{
    public interface ISkinChangerView
    {
        IReadOnlyDictionary<SkinType, SkinView> Skins { get; }
    }
}