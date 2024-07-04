namespace Sources.Scripts.PresentationsInterfaces.Views.BossPeaces
{
    public interface IBossPieceView
    {
        bool IsDestroyed { get; }
        void Explode();
    }
}