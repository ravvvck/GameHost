using GameHost.Api;
using GameHost.Api.Middleware;
using GameHost.Application;
using GameHost.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddPresentation();
    builder.Services.AddControllers();

}



var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}



