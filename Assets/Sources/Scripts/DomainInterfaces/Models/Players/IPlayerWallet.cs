using System;

namespace Sources.Scripts.DomainInterfaces.Models.Players
{
    public interface IPlayerWallet
    {
        event Action MoneyChanged;
        
        public int Money { get; }
    }
}