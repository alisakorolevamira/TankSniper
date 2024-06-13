namespace Sources.Scripts.PresentationsInterfaces.Views.Constructions
{
    public interface IConstruct<in T>
    {
        void Construct(T uiAnimator);
    }
}