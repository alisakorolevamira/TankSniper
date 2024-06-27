using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views.Players.SkinTypes;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Players
{
    public class SkinView : View, ISkinView
    {
        [SerializeField] private SkinType _skinType;

        public SkinType SkinType => _skinType;
        public Vector3 CurrentScale => transform.localScale;

        public void SetScale(Vector3 scale)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, scale, InventoryTankConst.DistanceDelta);
        }
    }
}