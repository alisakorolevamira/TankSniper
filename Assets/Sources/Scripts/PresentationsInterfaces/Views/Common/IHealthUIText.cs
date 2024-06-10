using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.UI.Texts;

namespace Sources.Scripts.PresentationsInterfaces.Views.Common
{
    public interface IHealthUIText
    {
        IReadOnlyList<IUIText> DamageTexts { get; }

    }
}