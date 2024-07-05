using UnityEngine;

namespace Sources.Scripts.Domain.Models.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "LocationSpritesConfig", menuName = "LocationSpritesConfig", order = 51)]
    public class LocationSpritesConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite FirstLocation { get; private set; }
        [field: SerializeField] public Sprite SecondLocation { get; private set; }
        [field: SerializeField] public Sprite ThirdLocation { get; private set; }
    }
}