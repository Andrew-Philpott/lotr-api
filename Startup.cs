using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lotr.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Lotr
{
  public static class Extensions
  {
    public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
    {
      var connectionString = config["ConnectionStrings:DefaultConnection"];
      services.AddDbContext<LotrContext>(o => o.UseMySql(connectionString));
    }
  }

  public class Startup
  {

    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      services.AddControllers();

      services.ConfigureMySqlContext(_configuration);


    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseStaticFiles();

      app.UseRouting();

      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}