using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.DomainInterfaces.Models.Players;

namespace Sources.Scripts.Domain.Models.Players
{
    public class PlayerWallet : IPlayerWallet, IEntity
    {
        private PlayerWalletData _data = new ();
        
        public PlayerWallet(string id)
        {
            Id = id;
            Money = PlayerConst.DefaultMoney;
        }

        public event Action MoneyChanged;

        public string Id { get; }
        public int Money { get; private set; }
        
        public void Save()
        {
            _data.Id = Id;
            _data.Money = Money;
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            Money = _data.Money;
        }

        public void AddMoney (int amount)
        {
            if (amount < 0)
                return;
            
            Money += amount;
            MoneyChanged?.Invoke();
        }

        public bool TryRemoveMoney(int amount)
        {
            if (Money < amount)
                return false;
            
            Money -= amount;
            MoneyChanged?.Invoke();
            return true;
        }
    }
}