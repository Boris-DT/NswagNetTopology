using NetTopologySuite.IO.Converters;

namespace Nswag13_20_0
{
    internal class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register Controllers
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    var geoJsonConverterFactory = new GeoJsonConverterFactory();
                    options.JsonSerializerOptions.Converters.Add(geoJsonConverterFactory);
                });

            // Register Swagger
            services.AddOpenApiDocument(document =>
            {
                document.PostProcess = d =>
                {
                    d.Info.Version = "v1";
                    d.Info.Title = "Geo API";
                    d.Info.Description = "A bunch of API to help with location based tasks like Geocoding, ...";
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles(); // Search for default or index pages
            app.UseStaticFiles(); // Search after pages in the wwwroot folder

            app.UseHttpLogging();

            app.UseRouting();

            if (env.IsDevelopment())
            {
                // Add OpenAPI/Swagger middleware
                app.UseOpenApi(); // Serves the registered OpenAPI/Swagger documents by default on `/swagger/{documentName}/swagger.json`
                app.UseSwaggerUi3(
                    settings => // Serves the Swagger UI 3 web ui to view the OpenAPI/Swagger documents by default on `/swagger`
                    {
                        settings.TransformToExternalPath = (internalUiRoute, request) =>
                        {
                            // See: https://github.com/RSuter/NSwag/issues/1934 & https://github.com/RSuter/NSwag/wiki/AspNetCore-Middleware#hosting-as-an-iis-virtual-application

                            if (internalUiRoute.StartsWith("/", StringComparison.Ordinal) &&
                                internalUiRoute.StartsWith(request.PathBase, StringComparison.Ordinal) == false)
                                return request.PathBase + internalUiRoute;

                            return internalUiRoute;
                        };

                        settings.DocExpansion = "list";

                        settings.DefaultModelsExpandDepth = 0;
                    });
            }

            // Configure endpoints
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}