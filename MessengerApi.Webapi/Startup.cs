using MessengerApi.Business.Models;
using MessengerApi.DAL;
using MessengerApi.DAL.Configuration;
using MessengerApi.DAL.Repository;
using MessengerApi.Services;
using MessengerApi.Services.Configuration;
using MessengerApi.Services.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MessengerApi.Webapi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MessengerApi.Webapi", Version = "v1" });
            });

            services.Configure<AppConfig>(x => x.AppName = Configuration.GetValue<string>("AppName"));

            services.Configure<FirestoreConfig>(x => Configuration.GetSection("Firebase:Firstore").Bind(x));

            services.Configure<DispatchOptions>(x => Configuration.GetSection("Dispatchers").Bind(x));
            services.AddScoped<DispatcherService>();

            services.AddScoped<DataContext>();
            services.AddScoped<RepositoryBase<MessageModel>, Messengerepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MessengerApi.Webapi v1"));

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
