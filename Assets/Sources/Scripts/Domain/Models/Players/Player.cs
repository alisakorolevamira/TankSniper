using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Domain.Models.Weapons;

namespace Sources.Scripts.Domain.Models.Players
{
    public class Player
    {
        public Player(
            PlayerWallet playerWallet,
            CharacterHealth characterHealth,
            PlayerAttacker playerAttacker,
            Weapon weapon)
        {
            PlayerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            CharacterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            PlayerAttacker = playerAttacker ?? throw new ArgumentNullException(nameof(playerAttacker));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public PlayerWallet PlayerWallet { get; }

        public CharacterHealth CharacterHealth { get; }
        
        public PlayerAttacker PlayerAttacker { get; }
        public Weapon Weapon { get; }
    }
}