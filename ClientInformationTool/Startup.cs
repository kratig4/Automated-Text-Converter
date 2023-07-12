using ClientInformationServices.Services.Impl;

namespace ClientInformationTool
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddXmlSerializerFormatters();

            services.AddControllers();

            services.AddSingleton(Configuration);

            services.AddScoped<ClientInformationServices.Services.IAudioToTextService, AudioToTextService>();
            services.AddScoped<ClientInformationServices.Services.IPdfToText, PdfToText>();
            services.AddScoped<ClientInformationServices.Services.IImageToText, ImageToText>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName.Equals(Environments.Development))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
