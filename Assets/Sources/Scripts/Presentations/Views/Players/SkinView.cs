using Sources.Scripts.Presentations.Views.Players.SkinTypes;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Players
{
    public class SkinView : View, ISkinView
    {
        [SerializeField] private SkinType _skinType;

        public SkinType SkinType => _skinType;
    }
}