using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Materials;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Players.Configs
{
    [CreateAssetMenu(fileName = "MaterialViewsConfig", menuName = "MaterialViewsConfig", order = 51)]
    public class MaterialViewsConfig : ScriptableObject
    {
        [field: SerializeField] public List<MaterialView> Materials { get; private set; }
    }
}