using LuhnApiService.DTO;

namespace LuhnApiService.CardValidatorFunction
{
    public interface ICardValidatorFnc
    {
        CardValidatedStatus CardLengthValidator(string CardNumber);
        CardValidatedStatus CardProviderValidate(string CardNumber,CardValidatedStatus PreResult);
        CardValidatedStatus CardNumberValidate(string CardNumber, CardValidatedStatus PreResult);
    }
}
