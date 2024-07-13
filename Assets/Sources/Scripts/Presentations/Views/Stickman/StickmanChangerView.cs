using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Controllers.Presenters.Stickman;
using Sources.Scripts.PresentationsInterfaces.Views.Stickman;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Stickman
{
    public class StickmanChangerView : PresentableView<StickmanChangerPresenter>, IStickmanChangerView
    {
        [SerializeField] private List<StickmanView> _stickmanViews;

        private Dictionary<StickmanType, StickmanView> _stickmen;

        public IReadOnlyDictionary<StickmanType, StickmanView> Stickmen => _stickmen;
        public StickmanView CurrentStickmanView { get; private set; }

        private void Awake()
        {
            _stickmen = _stickmanViews.ToDictionary(stickman => stickman.StickmanType, stickman => stickman);
        }

        public void SetCurrentStickman(StickmanType stickmanType)
        {
            CurrentStickmanView = _stickmen[stickmanType];
        }
    }
}