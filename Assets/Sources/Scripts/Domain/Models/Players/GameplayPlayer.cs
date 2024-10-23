using System;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Domain.Models.Weapons;

namespace Sources.Scripts.Domain.Models.Players
{
    public class GameplayPlayer : Player
    {
        public GameplayPlayer(
            PlayerWallet playerWallet,
            CharacterHealth characterHealth,
            PlayerAttacker playerAttacker,
            Weapon weapon)
        : base(playerWallet)
        {
            CharacterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            PlayerAttacker = playerAttacker ?? throw new ArgumentNullException(nameof(playerAttacker));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }
        
        public CharacterHealth CharacterHealth { get; }
        
        public PlayerAttacker PlayerAttacker { get; }
        public Weapon Weapon { get; }
    }
}