using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Orders.Application.DependencyInjection;
using Orders.Infrastructure.DependencyInjection;

namespace Orders
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOrdersApplication()
                .AddOrdersInfrastructure()
                .AddSingleton<IMediator, Mediator>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                var executeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Orders API", Version = "v1"});
                var xmlDocPath = Path.Combine(executeDirectory ?? "", "Orders.xml");
                c.IncludeXmlComments(xmlDocPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseSwagger(c => { c.RouteTemplate = "api/docs/{documentName}/swagger.json"; });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api/docs";
                c.SwaggerEndpoint("/api/docs/v1/swagger.json", "Orders API");
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}