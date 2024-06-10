using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Common;

namespace Sources.Scripts.Domain.Models.Players
{
    public class Player
    {
        public Player(
            PlayerWallet playerWallet,
            CharacterHealth characterHealth)
        //CharacterAttacker characterAttacker)
        {
            PlayerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            CharacterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            //CharacterAttacker = characterAttacker ?? throw new ArgumentNullException(nameof(characterAttacker));
        }

        public PlayerWallet PlayerWallet { get; }

        public CharacterHealth CharacterHealth { get; }
        
        //public CharacterAttacker CharacterAttacker { get; }
    }
}