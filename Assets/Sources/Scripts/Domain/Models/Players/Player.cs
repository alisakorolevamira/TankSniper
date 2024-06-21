using System;

namespace Sources.Scripts.Domain.Models.Players
{
    public class Player
    { 
        public Player(PlayerWallet playerWallet)
        {
            PlayerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
        }
        
        public PlayerWallet PlayerWallet { get; }
    }
}