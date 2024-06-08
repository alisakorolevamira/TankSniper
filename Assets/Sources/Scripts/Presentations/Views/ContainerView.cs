using Sources.Scripts.PresentationsInterfaces.Views;

namespace Sources.Scripts.Presentations.Views
{
    public class ContainerView : View
    {
        public void AppendChild(IView view) =>
            view.SetParent(transform);
    }
}