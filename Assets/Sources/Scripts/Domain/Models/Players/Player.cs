using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Common;

namespace Sources.Scripts.Domain.Models.Players
{
    public class Player
    {
        public Player(
            PlayerWallet playerWallet,
            CharacterHealth characterHealth,
            PlayerAttacker playerAttacker)
        {
            PlayerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            CharacterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            PlayerAttacker = playerAttacker ?? throw new ArgumentNullException(nameof(playerAttacker));
        }

        public PlayerWallet PlayerWallet { get; }

        public CharacterHealth CharacterHealth { get; }
        
        public PlayerAttacker PlayerAttacker { get; }
    }
}