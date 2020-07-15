using AutoMapper;
using BL;
using BL.Helper;
using BL.Interfaces;
using DAL;
using DAL.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLUtils;
using System.Reflection;

namespace CVApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        

            services.AddDistributedMemoryCache();
            services.AddSession(opts =>
            {
                opts.Cookie.IsEssential = true; // make the session cookie Essential
            });
            services.AddMvc();
            services.AddOptions();
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(IUsersBL),typeof(UsersBL));
            services.AddScoped(typeof(IUsersDAL), typeof(UsersDAL));
            services.AddScoped(typeof(IAdminBL), typeof(AdminBl));
            services.AddScoped(typeof(IAdminDAL), typeof(AdminDAL));
            services.AddScoped(typeof(ISQLUtils), typeof(SQLUtils.SQLUtils));
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/User/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
