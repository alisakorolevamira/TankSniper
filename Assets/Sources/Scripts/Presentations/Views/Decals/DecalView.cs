using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.PresentationsInterfaces.Views.Decal;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Decals
{
    public class DecalView : View, IDecalView
    {
        [SerializeField] private DecalType _decalType;
        [SerializeField] private Sprite _decal;

        public DecalType Type => _decalType;
        public Sprite Decal => _decal;
    }
}