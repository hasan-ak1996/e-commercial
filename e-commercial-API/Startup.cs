
using e_commercial_API.Errors;
using e_commercial_API.Extensions;
using e_commercial_API.Middleware;
using e_commercial_Domain;
using e_commercial_Repository.Helper;
using e_commercial_Repository.IRepository;
using e_commercial_Repository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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
using System.Threading.Tasks;

namespace e_commercial_API
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
            //this method is extension method to IServiceCollection
            services.AddApplicationServices();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddDbContext<StoreContext>(
                    x => x.UseSqlServer(
                            Configuration.GetConnectionString("ConnectionDefault")
                        )
                );

            services.AddSwaggerDocumentaion();
            // for determinate which client can conntecting with this api 
            // set this origin on header in request that sending from client
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                 {
                     // just client with url https://localhost:4200 can connecting with this api
                     policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                 });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentaion();
            }

            // handel exception error in development mode and production mode

            app.UseMiddleware<ExceptionMiddelware>();

            // handle not found response
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
