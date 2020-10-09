using AutoMapper;
using BillOfMaterials.Business;
using BillOfMaterials.Core;
using BillOfMaterials.Core.Services;
using BillOfMaterials.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace BillOfMaterials.WebApi
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
            //json recursive looping setup
            services.AddControllers().AddNewtonsoftJson(x=>x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // unitofwork's dependency setup
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // services' dependency setup
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();

            // connection string setup
            services.AddDbContext<BillOfMaterialsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BillOfMaterialsDb"), x => x.MigrationsAssembly("BillOfMaterials.DataAccess")));

            // swagger configuration
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Ürün Aðacý API", Version = "v1" });
            });

            // automapper setup
            services.AddAutoMapper(typeof(Startup));

            //json recursive looping setup
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // swagger configurations
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ürün Aðacý API V1");
            });
        }
    }
}
