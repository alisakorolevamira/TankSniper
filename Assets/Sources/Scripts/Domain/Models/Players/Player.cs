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