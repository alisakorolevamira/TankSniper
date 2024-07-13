using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.PresentationsInterfaces.Views.Stickman;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Stickman
{
    public class StickmanView : View, IStickmanView
    {
        [SerializeField] private StickmanType _stickmanType;

        public StickmanType StickmanType => _stickmanType;
        public Vector3 CurrentScale => transform.localScale;

        public void SetScale(Vector3 scale) => 
            transform.localScale = Vector3.MoveTowards(transform.localScale, scale, ShopConst.DistanceDelta);
    }
}