using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Players;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IPlayerWalletDtoMapper
    {
        PlayerWalletDto MapModelToDto(PlayerWallet playerWallet);
        PlayerWallet MapDtoToModel(PlayerWalletDto playerWalletDto);
    }
}