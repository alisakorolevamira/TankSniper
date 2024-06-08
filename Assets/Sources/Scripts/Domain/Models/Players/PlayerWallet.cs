using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.DomainInterfaces.Models.Players;

namespace Sources.Scripts.Domain.Models.Players
{
    public class PlayerWallet : IPlayerWallet, IEntity
    {
        public PlayerWallet(
            int money,
            string id)
        {
            Money = money;
            Id = id;
        }

        public PlayerWallet(PlayerWalletDto playerWalletDto)
        {
            Money = playerWalletDto.Money;
            Id = playerWalletDto.Id;
        }

        public event Action MoneyChanged;

        public string Id { get; }
        public Type Type => GetType();
        public int Money { get; private set; }

        public void AddMoney (int amount)
        {
            if (amount < 0)
                return;
            
            Money += amount;
            MoneyChanged?.Invoke();
        }

        public bool TryRemoveCoins(int amount)
        {
            if (Money < amount)
                return false;
            
            Money -= amount;
            MoneyChanged?.Invoke();
            return true;
        }
    }
}