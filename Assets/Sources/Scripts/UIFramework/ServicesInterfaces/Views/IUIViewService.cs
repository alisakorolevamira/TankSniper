using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.ServicesInterfaces.Views
{
    public interface IUIViewService
    {
        void Handle(IEnumerable<FormCommandId> commandIds);
    }
}