using LuhnApiService.CardValidatedChain;
using LuhnApiService.CardValidatedChain.Chain;
using LuhnApiService.CardValidatorFunction;
using LuhnApiService.CardValidatorFunction.Repository;
using LuhnApiService.DTO;
using LuhnApiService.helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

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
        CardLenghtValidater.SetNextHandler(CardProviderValidater);
        CardProviderValidater.SetNextHandler(CardNumberValidater);

        CardValidatedStatus Result = CardLenghtValidater.Handler(body.CardNumber, new CardValidatedStatus() 
        { IsCardLengthValid=false,
        IsCardValid=false,
        CardProvider = CardProvider.None.ToString()
           
        });

        

        
        if (body == null)
        {
      
            return Results.BadRequest(new { status = APTResponceStatus.SUCCESS.ToString()    , message = "Invalid request body" });
        }

        
        return Results.Ok(new { status = APTResponceStatus.SUCCESS.ToString(), message = body });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { status = APTResponceStatus.FAILL.ToString(), message = "Invalid request body" });
    }
});

app.Run();
