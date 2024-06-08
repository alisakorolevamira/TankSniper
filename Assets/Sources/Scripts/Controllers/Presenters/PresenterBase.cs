using Sources.Scripts.ControllersInterfaces.Presenters;

namespace Sources.Scripts.Controllers.Presenters
{
    public abstract class PresenterBase : IPresenter
    {
        public virtual void Enable()
        {
        }

        public virtual void Disable()
        {
        }
    }
}