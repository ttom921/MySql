using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gomo.CC.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;

namespace EmptyWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
          
        }
       
        
        //設定資料庫
        void SetUPDataBase(IServiceCollection services)
        {
            //services.AddDbContext<GomoCCDBContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("GomoLocalDatabase")));
            // services.AddDbContext<BloggingContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("myHome")));
            string connstr = null;
            connstr = Configuration.GetConnectionString("GomoDatabase");
            //log.Info("設定資料庫連線=" + connstr);
            services.AddDbContext<GomoCCDBContext>(options =>
                      options.UseMySql(connstr));
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //log.Info("start ConfigureServices...");
            //連結資料庫
            SetUPDataBase(services);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //log.Warn("Environment=" + env.EnvironmentName);
           // loggerFactory.AddNLog();
            //ILogger log= loggerFactory.CreateLogger("WebDebug");
            //log.LogTrace("Configure-------------------------");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
