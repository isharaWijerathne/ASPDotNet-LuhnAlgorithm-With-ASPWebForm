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
