using LuhnApiService.DTO;

namespace LuhnApiService.CardValidatedChain
{
    public interface ICardValidatorChainHandler
    {
        public void SetNextHandler(ICardValidatorChainHandler CardValidatorChainHandler);
        public CardValidatedStatus Handler(string CartNumber, CardValidatedStatus PreResult);
    }
}
