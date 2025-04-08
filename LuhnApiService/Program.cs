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
        // Read the request body (assuming JSON content)
        var body = await request.ReadFromJsonAsync<CardValidatorRequest>();
 

        // Your logic to process the request body
        // For example, validating the card:
        if (body == null)
        {
      
            return Results.BadRequest(new { status = HttpResponceEnum.SUCCESS.ToString()    , message = "Invalid request body" });
        }

        // Assuming successful validation:
        return Results.Ok(new { status = HttpResponceEnum.SUCCESS.ToString(), message = body });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { status = HttpResponceEnum.FAILL.ToString(), message = "Invalid request body" });
    }
});

app.Run();
