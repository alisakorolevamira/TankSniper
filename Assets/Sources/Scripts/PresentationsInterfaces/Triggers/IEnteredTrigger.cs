using System;

namespace Sources.Scripts.PresentationsInterfaces.Triggers
{
    public interface IEnteredTrigger<out T>
    {
        public event Action<T> Entered;
    }
}