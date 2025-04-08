// See https://aka.ms/new-console-template for more information
using LuhnApiService.CardValidatedChain;
using LuhnApiService.CardValidatedChain.Chain;
using LuhnApiService.CardValidatorFunction;
using LuhnApiService.CardValidatorFunction.Repository;
using LuhnApiService.DTO;

Console.WriteLine("Hello, World!");


//ValicaterFiction
ICardValidatorFnc CardValidatorFunc = new CardValidatorFnc();

//Validate Chain
ICardValidatorChainHandler CardLenghtValidater = new CardLengthValidator(CardValidatorFunc);
ICardValidatorChainHandler CardProviderValidater = new CardProviderValidator(CardValidatorFunc);
ICardValidatorChainHandler CardNumberValidater = new CardNumberValidator(CardValidatorFunc);

//Order Assing
CardLenghtValidater.SetNextHandler(CardProviderValidater); 
CardProviderValidater.SetNextHandler(CardNumberValidater);

CardValidatedStatus Result = CardLenghtValidater.Handler("4135410017215352", new CardValidatedStatus()
{
    IsCardLengthValid = false,
    IsCardValid = false,
    CardProvider = CardProvider.None.ToString()

});


Console.WriteLine(Result.CardProvider + " " +Result.IsCardValid + " " +Result.IsCardLengthValid);

