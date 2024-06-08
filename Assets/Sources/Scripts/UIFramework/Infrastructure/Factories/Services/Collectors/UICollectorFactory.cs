using System;
using System.Collections.Generic;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Views.Forms;
using Sources.Scripts.UIFramework.Presentations.Buttons;
using Sources.Scripts.UIFramework.Presentations.Views;

namespace Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors
{
    public class UICollectorFactory
    {
        private readonly UIButtonFactory _uiButtonFactory;
        private readonly UIViewFactory _uiViewFactory;
        private readonly IHud _hud;
        
        protected UICollectorFactory(
            UIButtonFactory uiButtonFactory,
            UIViewFactory uiViewFactory,
            IHud hud)
        {
            _uiButtonFactory = uiButtonFactory ??
                               throw new ArgumentNullException(nameof(uiButtonFactory));
            _uiViewFactory = uiViewFactory ?? throw new ArgumentNullException(nameof(uiViewFactory));
            _hud = hud ?? throw new ArgumentNullException(nameof(hud));
        }

        public void Create()
        {
            CreateFormButtons(_hud.UICollector.UIFormButtons);
            CreateUiContainers(_hud.UICollector.UIContainers);
        }

        private void CreateFormButtons(IEnumerable<UIButton> formButtons)
        {
            foreach (UIButton formButton in formButtons)
                _uiButtonFactory.Create(formButton);
        }

        private void CreateUiContainers(IEnumerable<UIView> containers)
        {
            foreach (UIView container in containers)
                _uiViewFactory.Create(container);
        }
    }
}