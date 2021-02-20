using Prodap.ListaLeitura.Persistencia;
using Prodap.ListaLeitura.Seguranca;
using Prodap.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Prodap.WebApp
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<LeituraContext>(options => {
        options.UseSqlServer(Configuration.GetConnectionString("ListaLeitura"));
      });

      services.AddDbContext<AuthDbContext>(options => {
        options.UseSqlServer(Configuration.GetConnectionString("AuthDB"));
      });

      services.AddIdentity<Usuario, IdentityRole>(options =>
      {
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
      }).AddEntityFrameworkStores<AuthDbContext>();

      services.ConfigureApplicationCookie(options => {
        options.LoginPath = "/Usuario/Login";
      });

      services.AddTransient<IRepository<Vendas>, RepositorioBaseEF<Vendas>>();
      services.AddTransient<IRepository<Produto>, RepositorioBaseEF<Produto>>();

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();
      app.UseAuthentication();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
