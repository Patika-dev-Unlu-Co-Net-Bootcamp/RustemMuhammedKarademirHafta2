using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnluCo.NetBootcamp.Odev2.DBOperations;
using UnluCo.NetBootcamp.Odev2.Middlewares;
using UnluCo.NetBootcamp.Odev2.Services;

namespace UnluCo.NetBootcamp.Odev2
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UnluCo.NetBootcamp.Odev2", Version = "v1" });
            });
            services.AddDbContext<CarSystemDbContext>(options => options.UseInMemoryDatabase(databaseName:"CarSystemDB"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<ILoggerService, DBLoggerService>();//Program icerisinde ILoggerService istenirse DBLoggerService aktif edilir.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UnluCo.NetBootcamp.Odev1 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseGlobalExceptionMiddleware();//program akisi icerisinde kendi yazdigim middleware devreye girer

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
