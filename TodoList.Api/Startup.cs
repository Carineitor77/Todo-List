using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TodoList.Data.Context;
using TodoList.Data.Entities;
using TodoList.Data.Repository;

namespace TodoList.Api
{
    class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddControllers();
            services.AddDbContext<ContextApp>(builder =>
            {
                builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("TodoList.Api"));
            });

            services.AddScoped<IRepository<Affair>, AffairsRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo List Api", Version = "v1" });
            });

            services.AddCors();

            /*services.AddCors(c => c.AddPolicy(name: "TodoListPolicy", options =>
            {
                options.WithOrigins("https://localhost:7162")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));*/
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(c => 
                c.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}