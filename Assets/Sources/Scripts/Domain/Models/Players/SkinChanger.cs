using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Presentations.Views.Players.SkinTypes;

namespace Sources.Scripts.Domain.Models.Players
{
    public class SkinChanger
    {
        private Dictionary<int, SkinType> _skinTypes = new()
        {
            {1, SkinType.First },
            {2, SkinType.Second},
            {3, SkinType.Third},
            {4, SkinType.Fourth},
            {5, SkinType.Fifth},
            {6, SkinType.Sixth},
            {7, SkinType.Seventh},
            {8, SkinType.Eighth}
        };
        
        public SkinChanger(Upgrader upgrader)
        {
            ChangeSkin(upgrader.CurrentLevel);
        }

        public SkinType CurrentSkin { get; set; }
        public event Action CurrentSkinChanged;
        
        //сделать диктионари об открытых и закрытых модельках

        public void ChangeSkin(int level)
        {
            if (level is < 0 or > PlayerConst.MaxLevel)
                return;
            
            CurrentSkin = _skinTypes[level];
            CurrentSkinChanged?.Invoke();
        }
    }
}