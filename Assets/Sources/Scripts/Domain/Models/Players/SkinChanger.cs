using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Players
{
    public class SkinChanger : IEntity
    {
       //private readonly Upgrader _upgrader;

       //private Dictionary<int, SkinType> _skinTypes = new()
       //{
       //    {1, SkinType.First },
       //    {2, SkinType.Second},
       //    {3, SkinType.Third},
       //    {4, SkinType.Fourth},
       //    {5, SkinType.Fifth},
       //    {6, SkinType.Sixth},
       //    {7, SkinType.Seventh},
       //    {8, SkinType.Eighth}
       //};
        
        public SkinChanger(SkinType currentSkin, MaterialType currentMaterial, DecalType currentDecal, string id)
        {
            CurrentSkin = currentSkin;
            CurrentMaterial = currentMaterial;
            CurrentDecal = currentDecal;
            Id = id;
        }

        public SkinType CurrentSkin { get; set; }
        public MaterialType CurrentMaterial { get; set; }
        public DecalType CurrentDecal { get; set; }
        public string Id { get; }
        public Type Type => GetType();
        public event Action CurrentSkinChanged;
        public event Action<Material> CurrentMaterialChanged;
        public event Action DefaultMaterialSetted;
        public event Action DecalRemoved;
        public event Action<Sprite> CurrentDecalChanged; 
        
        //сделать диктионари об открытых и закрытых модельках

        public void ChangeSkin(SkinType skinType)
        {
            CurrentSkin = skinType;
            CurrentSkinChanged?.Invoke();
        }

        public void ChangeSkin(int level)
        {
            //CurrentSkin = _skinTypes[level];
            //ChangeSkin(CurrentSkin);
        }

        public void ChangeMaterial(Material material) => 
            CurrentMaterialChanged?.Invoke(material);

        public void SetDefaultMaterial() => 
            DefaultMaterialSetted?.Invoke();

        public void ChangeDecal(Sprite decal) => 
            CurrentDecalChanged?.Invoke(decal);

        public void RemoveDecal() => 
            DecalRemoved?.Invoke();
    }
}