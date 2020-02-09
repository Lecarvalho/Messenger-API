using MessagerApi.Business.Models;
using MessagerApi.DAL;
using MessagerApi.DAL.Configuration;
using MessagerApi.DAL.Repository;
using MessagerApi.Services;
using MessagerApi.Services.Configuration;
using MessagerApi.Services.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessagerApi.Webapi
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
            services.Configure<FirestoreConfig>(x => Configuration.GetSection("Firebase:Firstore").Bind(x));

            services.Configure<DispatcherConfig>(x => Configuration.GetSection("Dispatchers").Bind(x));
            services.AddScoped<DispatcherService>();

            services.AddScoped<DataContext>();
            services.AddScoped<RepositoryBase<MessageModel>, MessageRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
