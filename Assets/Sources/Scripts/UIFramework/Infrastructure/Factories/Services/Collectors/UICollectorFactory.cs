using System;
using System.Collections.Generic;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Views.Forms;
using Sources.Scripts.UIFramework.Presentations.Views;

namespace Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors
{
    public class UICollectorFactory
    {
        private readonly UIViewFactory _uiViewFactory;
        private readonly IHud _hud;
        
        protected UICollectorFactory(
            UIViewFactory uiViewFactory,
            IHud hud)
        {
            _uiViewFactory = uiViewFactory ?? throw new ArgumentNullException(nameof(uiViewFactory));
            _hud = hud ?? throw new ArgumentNullException(nameof(hud));
        }

        public void Create()
        {
            CreateUiContainers(_hud.UICollector.UIContainers);
        }

        private void CreateUiContainers(IEnumerable<UIView> containers)
        {
            foreach (UIView container in containers)
                _uiViewFactory.Create(container);
        }
    }
}