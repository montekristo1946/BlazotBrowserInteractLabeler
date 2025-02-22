using BrowserInteractLabeler.Common;
using BrowserInteractLabeler.Repository;
using BrowserInteractLabeler.Web.Infrastructure;
using BrowserInteractLabeler.Web.Infrastructure.Buffers;
using BrowserInteractLabeler.Web.Infrastructure.Configs;
using BrowserInteractLabeler.Web.Infrastructure.Constructors;
using BrowserInteractLabeler.Web.Infrastructure.Handlers;

namespace BrowserInteractLabeler.Web.Extension;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddSingleton<ServiceConfigs>(provider => ServiceConfigs.LoadInFile());
        services.AddSingleton<IRepository>(provider => new SqlRepository());
        services.AddSingleton<SettingsHandler>();


        services.AddSingleton<SvgConstructor>();
        services.AddSingleton<Helper>();
        services.AddSingleton<CacheModel>();
        services.AddSingleton<MarkupHandler>();
        services.AddSingleton<CacheAnnotation>();
        services.AddSingleton<NavigationHandler>();
        services.AddSingleton<MoveImagesHandler>();
        services.AddSingleton<KeyMapHandler>();

        services.AddSingleton<ProjectsLocalHandler>();



    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}