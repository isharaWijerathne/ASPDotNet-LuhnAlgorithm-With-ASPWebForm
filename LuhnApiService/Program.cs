using LuhnApiService.CardValidatedChain;
using LuhnApiService.CardValidatedChain.Chain;
using LuhnApiService.CardValidatorFunction;
using LuhnApiService.CardValidatorFunction.Repository;
using LuhnApiService.DTO;
using LuhnApiService.helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddCors(options => options.AddPolicy("SiteCrossPolicy",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader()
    ));

var app = builder.Build();

app.UseCors("SiteCrossPolicy");
app.UseHttpsRedirection();



app.MapPost("/v1/card-validator", async (HttpRequest request) =>
{
    try
    {
       
        var body = await request.ReadFromJsonAsync<HttpPostCardValidatorRequest>();
 

        //ValicaterFiction
        ICardValidatorFnc CardValidatorFunc = new CardValidatorFnc();

        //Validate Chain
        ICardValidatorChainHandler CardLenghtValidater = new CardLengthValidator(CardValidatorFunc);
        ICardValidatorChainHandler CardProviderValidater = new CardProviderValidator(CardValidatorFunc);
        ICardValidatorChainHandler CardNumberValidater = new CardNumberValidator(CardValidatorFunc);

        //Order Assing
        CardLenghtValidater.SetNextHandler(CardNumberValidater);
        CardNumberValidater.SetNextHandler(CardProviderValidater);

        CardValidatedStatus Result = CardLenghtValidater.Handler(body.CardNumber, new CardValidatedStatus() 
        { IsCardLengthValid=false,
        IsCardValid=false,
        CardProvider = CardProvider.None.ToString()
           
        });

        if (Result.IsCardValid == false || Result.IsCardLengthValid == false || Result.CardProvider == CardProvider.None.ToString()) {

            throw new Exception("Invalid card details");
        }        
        return Results.Ok(new { status = APTResponceStatus.SUCCESS.ToString(), message = Result });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { status = APTResponceStatus.FAILL.ToString(), message = ex.Message });
    }
});

app.Run();
