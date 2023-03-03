var builder = WebApplication.CreateBuilder(args);

// Dependency injection setup
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Chayanne's Contact API",
        Description = "Chayanne's contact information API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Chayanne",
            Url = new Uri("https://www.chayannerodriguez.com/"),
        }
    }); 
});

services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200", "https://localhost:4200", "https://www.chayannerodriguez.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);


// Middleware pipeline configuration
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact API");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();