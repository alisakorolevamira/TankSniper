using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Domain.Models.Weapons;
using UnityEngine;

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