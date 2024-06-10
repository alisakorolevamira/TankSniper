using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.Presentations.Views.Common
{
    public class CharacterHealthView : PresentableView<CharacterHealthPresenter>, ICharacterHealthView
    {
        public void TakeDamage(int damage) =>
            Presenter.TakeDamage(damage);
    }
}