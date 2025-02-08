
using FlotteApplication.Data;
using FlotteApplication.Repositories.Implementation;
using FlotteApplication.Repositories.Interface;

namespace FlotteApplication
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFacture,FactureRepository>();
            services.AddSingleton<DataSource>();
            services.AddScoped<IEngin,EnginRepository>();
            services.AddScoped<IProprietaire,ProprietaireRepository>();
            services.AddScoped<IAdmin,AdminRepository>();
            services.AddMvc();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapDefaultControllerRoute();
            });
        }
    }
}
