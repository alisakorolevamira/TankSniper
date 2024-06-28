using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Materials;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Players.Configs
{
    [CreateAssetMenu(fileName = "PlayerViewMaterialsConfig", menuName = "PlayerViewMaterialsConfig", order = 51)]
    public class PlayerViewMaterialsConfig : ScriptableObject
    {
        [field: SerializeField] public List<MaterialView> Materials { get; private set; }
    }
}