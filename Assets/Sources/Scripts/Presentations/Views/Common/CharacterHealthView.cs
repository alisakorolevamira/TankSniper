using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Common
{
    public class CharacterHealthView : PresentableView<CharacterHealthPresenter>, ICharacterHealthView
    {
        public Vector3 Position => transform.position;
        public void TakeDamage(int damage) =>
            Presenter.TakeDamage(damage);
    }
}