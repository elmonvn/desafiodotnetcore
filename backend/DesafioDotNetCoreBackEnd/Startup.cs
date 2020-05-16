using DesafioDotNetCoreBackEnd.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DesafioDotNetCoreBackEnd
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
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Cadastro API", Version = "v1", Description = "Dev"
                });
            });

            services.AddDbContext<CadastroDbContext>(conn =>
                conn.UseSqlServer(Configuration.GetConnectionString("CadastroDbContext"))
            );

            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder => builder
                //.WithOrigins("http://localhost:3000", "https://localhost:3000", "http://172.25.0.4:3000")
                .AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastro API")
            );
        }
    }
}