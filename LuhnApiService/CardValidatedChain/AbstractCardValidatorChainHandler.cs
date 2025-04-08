using LuhnApiService.CardValidatorFunction;

namespace LuhnApiService.CardValidatedChain
{
    public abstract class AbstractCardValidatorChainHandler
    {
        public abstract ICardValidatorChainHandler CardValidatorChainHandler { get; set; }
        public abstract ICardValidatorFnc CardValidatorFnc { get; set; }    
    }
}
