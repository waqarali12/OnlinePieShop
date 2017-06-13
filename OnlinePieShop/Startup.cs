using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlinePieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlinePieShop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfigurationRoot _ConfigurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _ConfigurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => 
                                                options.UseSqlServer(_ConfigurationRoot.GetConnectionString("DefaultConnection")));
            //services.AddSingleton--single obj for all sessions
            //services.AddScoped-single object for one session  
            //services.AddTransient new obj whenever called
            services.AddTransient<IPieRepository, PieRepository>(); 
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            DbInitializer.Seed(app);
        }
    }   
}
        