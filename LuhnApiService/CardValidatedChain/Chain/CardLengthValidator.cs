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
<<<<<<< HEAD

            if (CardValidatorChainHandler == null)
            {

                return CardValidatorFnc.CardLengthValidator(CartNumber, PreResult);
=======
            if (CardValidatorChainHandler == null)
            {

                return this.CardValidatorFnc.CardLengthValidator(CartNumber, PreResult);
>>>>>>> 48cd545beeb6e2117089cecceefdfea0ddf9c7b4
            }

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
