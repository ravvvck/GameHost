using GameHost.Api;
using GameHost.Api.Middleware;
using GameHost.Application;
using GameHost.Application.Authorization;
using GameHost.Infrastructure;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services.AddTransient<ErrorHandlingMiddleware>();
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



