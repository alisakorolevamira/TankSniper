using System;
using Sources.Scripts.Presentations.Views.Players.SkinTypes;

namespace Sources.Scripts.Domain.Models.Players
{
    public class SkinChanger
    {
        public SkinChanger()
        {
            
        }

        public SkinType CurrentSkin { get; set; }
        public event Action CurrentSkinChanged;
        
        //сделать диктионари об открытых и закрытых модельках

        public void ChangeSkin(SkinType skinType)
        {
            CurrentSkin = skinType;
            CurrentSkinChanged?.Invoke();
        }
    }
}