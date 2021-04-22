using CrossCuttingLib.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
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

            ConfigureService.ConfigureDependenciesService(services);//fazendo injeção de dependencia em crosscutting/dependencyinjection/configureservice
            ConfigureRepository.ConfigureDependenciesRepository(services); //injeção de dependencia 

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "API whith DDD", 
                    Version = "v1", 
                    Description = "Aplicação em DDD", 
                    TermsOfService = new Uri ("https://maxgi.com.br/termoapiddd"),
                Contact = new OpenApiContact 
                { 
                    Name = "Maxsweel Rodrigues de Souza",
                    Email = "maxsweel@hotmail.com",
                    Url = new Uri("https://maxgi.com.br")
                },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de licença",
                        Url = new Uri("https://maxgi.com.br/termolicenca")
                    }
                
                });
            });
            

            /*
             * Configuração padrão Swagger 
             * services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application", Version = "v1" });
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
