using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Decals;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Players.Configs
{
    [CreateAssetMenu(fileName = "DecalViewsConfig", menuName = "DecalViewsConfig", order = 51)]
    public class DecalViewsConfig : ScriptableObject
    {
        [field: SerializeField] public List<DecalView> Decals { get; private set; }
    }
}