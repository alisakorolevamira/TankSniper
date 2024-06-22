using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.PresentationsInterfaces.Views.Constructions;
using Sources.Scripts.UIFramework.Presentations.Animations;

namespace Sources.Scripts.UIFramework.ServicesInterfaces
{
    public interface IViewService :  IEnable, IDisable, IConstruct<UIAnimator>
    {
    }
}