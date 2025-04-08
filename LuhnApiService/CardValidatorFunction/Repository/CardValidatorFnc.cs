using LuhnApiService.DTO;

namespace LuhnApiService.CardValidatorFunction.Repository
{
    public class CardValidatorFnc : ICardValidatorFnc
    {
        public CardValidatedStatus CardLengthValidator(string CardNumber, CardValidatedStatus PreResult)
        {
            if (CardNumber.Length == 15 || CardNumber.Length == 16)
            {
                return new CardValidatedStatus() {
                    CardProvider = CardProvider.None.ToString(),
                    IsCardLengthValid = true, // Card Length Status Updated
                    IsCardValid = false,
                };
            }
            else
            {
                return new CardValidatedStatus() {
                    CardProvider = CardProvider.None.ToString(),
                    IsCardLengthValid = false, //Card Length Status Updated
                    IsCardValid = false,
                };
            }
        }
       
        public CardValidatedStatus CardNumberValidate(string CardNumber, CardValidatedStatus PreResult)
        {
            var sum = 0;
            var shouldApplyDouble = true;
            for (var index = CardNumber.Length - 2; index >= 0; index--)
            {
                var currentDigit = (Int32)Char.GetNumericValue(CardNumber, index);
                if (shouldApplyDouble)
                {
                    if (currentDigit > 4)
                    {
                        sum += currentDigit * 2 - 9;
                    }
                    else
                    {
                        sum += currentDigit * 2;
                    }
                }
                else
                {
                    sum += currentDigit;
                }
                shouldApplyDouble = !shouldApplyDouble;
            }
            var checkDigit = 10 - (sum % 10);

             bool CardValidatedStatus = Char.GetNumericValue(CardNumber[^1]) == checkDigit;

            if (CardValidatedStatus) {

                var UpdatedStatus = PreResult;
                PreResult.IsCardValid = true;
                return UpdatedStatus;

            }

            return PreResult;
        }

        public CardValidatedStatus CardProviderValidate(string CardNumber, CardValidatedStatus PreResult)
        {
            //Auth AmEx
            if (
                Convert.ToInt32(CardNumber.Substring(0, 2)) == 34 || Convert.ToInt32(CardNumber.Substring(0, 2)) == 37
                ) { 
            
                var UpdatedStatus = PreResult;
                UpdatedStatus.CardProvider = CardProvider.AmEX.ToString();
                return UpdatedStatus;
            }

            //Auth Visa
            if (
                Convert.ToInt32(CardNumber.Substring(0,1)) == 4
                )
            {

                var UpdatedStatus = PreResult;
                UpdatedStatus.CardProvider = CardProvider.Visa.ToString();
                return UpdatedStatus;
            }

            //Auth MasterCard
            if (
                Convert.ToInt32(CardNumber.Substring(0, 2)) == 22 ||
                 Convert.ToInt32(CardNumber.Substring(0, 2)) >= 51 && Convert.ToInt32(CardNumber.Substring(0, 2)) <= 55
                )
            {

                var UpdatedStatus = PreResult;
                UpdatedStatus.CardProvider = CardProvider.MasterCard.ToString();
                return UpdatedStatus;
            }

            //Auth Discover
            if (
                Convert.ToInt32(CardNumber.Substring(0, 4)) == 6011
                )
            {

                var UpdatedStatus = PreResult;
                UpdatedStatus.CardProvider = CardProvider.Discover.ToString();
                return UpdatedStatus;
            }

            

            return PreResult;

           
        }
    }

        
    
}
