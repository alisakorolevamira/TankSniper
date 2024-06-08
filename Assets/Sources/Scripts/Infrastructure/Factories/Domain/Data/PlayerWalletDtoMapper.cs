using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class PlayerWalletDtoMapper : IPlayerWalletDtoMapper
    {
        public PlayerWalletDto MapModelToDto(PlayerWallet playerWallet)
        {
            return new PlayerWalletDto()
            {
                Money = playerWallet.Money,
                Id = playerWallet.Id,
            };
        }

        public PlayerWallet MapDtoToModel(PlayerWalletDto playerWalletDto) =>
            new(playerWalletDto);
    }
}