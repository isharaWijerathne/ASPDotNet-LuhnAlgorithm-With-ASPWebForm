using LuhnApiService.CardValidatorFunction;
using LuhnApiService.DTO;

namespace LuhnApiService.CardValidatedChain.Chain
{
    public class CardLengthValidator : AbstractCardValidatorChainHandler, ICardValidatorChainHandler
    {
        public override ICardValidatorChainHandler? CardValidatorChainHandler { get ; set; }
        public override ICardValidatorFnc? CardValidatorFnc { get; set ; }

        public CardLengthValidator(ICardValidatorFnc? cardValidatorFnc)
        {
            this.CardValidatorFnc = cardValidatorFnc;
        }

        public CardValidatedStatus Handler(string? CartNumber, CardValidatedStatus? PreResult)
        {
            return this.CardValidatorChainHandler.Handler(CartNumber,
                CardValidatorFnc.CardLengthValidator(CartNumber, PreResult)
                );
        }

        public void SetNextHandler(ICardValidatorChainHandler? CardValidatorChainHandler)
        {
            this.CardValidatorChainHandler = CardValidatorChainHandler;
        }
    }
}
