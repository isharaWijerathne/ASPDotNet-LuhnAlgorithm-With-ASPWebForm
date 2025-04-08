using LuhnApiService.CardValidatorFunction;
using LuhnApiService.DTO;

namespace LuhnApiService.CardValidatedChain.Chain
{
    public class CardProviderValidator : AbstractCardValidatorChainHandler, ICardValidatorChainHandler
    {
        public override ICardValidatorChainHandler? CardValidatorChainHandler { get; set; }
        public override ICardValidatorFnc? CardValidatorFnc { get; set ; }


        public CardProviderValidator(ICardValidatorFnc CardValidatorFnc)
        {
            this.CardValidatorFnc = CardValidatorFnc;
        }
        public CardValidatedStatus Handler(string CartNumber, CardValidatedStatus PreResult)
        {

            if (CardValidatorChainHandler == null)
            {
                return this.CardValidatorFnc.CardProviderValidate(CartNumber, PreResult);
            }

            return CardValidatorChainHandler.Handler(CartNumber, 
                this.CardValidatorFnc.CardProviderValidate(CartNumber,PreResult));
        }

        public void SetNextHandler(ICardValidatorChainHandler CardValidatorChainHandler)
        {
          this.CardValidatorChainHandler = CardValidatorChainHandler;
        }
    }
}
