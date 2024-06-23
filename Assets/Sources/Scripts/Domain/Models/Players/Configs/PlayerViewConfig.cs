using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Players.Configs
{
    [CreateAssetMenu(fileName = "PlayerViewConfig", menuName = "PlayerViewConfig", order = 51)]
    public class PlayerViewConfig : ScriptableObject
    {
        [field: SerializeField] public List<PlayerView> PlayerViews { get; private set; }
    }
}