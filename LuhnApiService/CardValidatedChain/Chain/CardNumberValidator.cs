using LuhnApiService.CardValidatorFunction;
using LuhnApiService.DTO;

namespace LuhnApiService.CardValidatedChain.Chain
{
    public class CardNumberValidator : AbstractCardValidatorChainHandler, ICardValidatorChainHandler
    {
        public override ICardValidatorChainHandler? CardValidatorChainHandler { get; set; }
        public override ICardValidatorFnc? CardValidatorFnc { get; set; }

        public CardNumberValidator(ICardValidatorFnc CardValidatorFnc)
        {
            this.CardValidatorFnc = CardValidatorFnc;   
        }

        public CardValidatedStatus Handler(string CartNumber, CardValidatedStatus PreResult)
        {
            return this.Handler(CartNumber,
                this.CardValidatorFnc.CardNumberValidate(CartNumber,PreResult));
        }

        public void SetNextHandler(ICardValidatorChainHandler CardValidatorChainHandler)
        {
            this.CardValidatorChainHandler = CardValidatorChainHandler;
        }
    }
}
