using System;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Players
{
    public class Player
    { 
        public Player(PlayerWallet playerWallet)
        {
            PlayerWallet = playerWallet;
        }
        
        public PlayerWallet PlayerWallet { get; }
    }
}