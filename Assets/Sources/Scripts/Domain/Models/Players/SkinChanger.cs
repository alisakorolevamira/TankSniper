using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.Presentations.Views.Decals;
using Sources.Scripts.Presentations.Views.Materials;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Players
{
    public class SkinChanger : IEntity
    {
        private SkinChangerData _data = new ();
        
        public SkinChanger(string id)
        {
            Id = id;
            CurrentSkin = SkinType.First;
            CurrentMaterial = MaterialType.Default;
            CurrentDecal = DecalType.Default;
        }

        public SkinType CurrentSkin { get; private set; }
        public MaterialType CurrentMaterial { get; private set; }
        public DecalType CurrentDecal { get; private set; }
        public string Id { get; }
        
        public event Action CurrentSkinChanged;
        public event Action<Material> CurrentMaterialChanged;
        public event Action DefaultMaterialSetted;
        public event Action DecalRemoved;
        public event Action<Sprite> CurrentDecalChanged; 
        
        //сделать диктионари об открытых и закрытых модельках
        
        public void Save()
        {
            _data.Id = Id;
            _data.CurrentSkinType = CurrentSkin;
            _data.CurrentMaterialType = CurrentMaterial;
            _data.CurrentDecalType = CurrentDecal;
            
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            CurrentSkin = _data.CurrentSkinType;
            CurrentMaterial = _data.CurrentMaterialType;
            CurrentDecal = _data.CurrentDecalType;
        }

        public void ChangeSkin(SkinType skinType)
        {
            CurrentSkin = skinType;
            CurrentSkinChanged?.Invoke();
        }

        public void ChangeMaterial(MaterialView materialView)
        {
            CurrentMaterial = materialView.Type;
            CurrentMaterialChanged?.Invoke(materialView.Material);
        }

        public void SetDefaultMaterial() => 
            DefaultMaterialSetted?.Invoke();

        public void ChangeDecal(DecalView decalView)
        {
            CurrentDecal = decalView.Type;
            CurrentDecalChanged?.Invoke(decalView.Decal);
        }

        public void RemoveDecal() => 
            DecalRemoved?.Invoke();
    }
}