using campeonato.AutoMapper;
using campeonato.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace campeonato
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(
                op =>
                {
                    op.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }
            );

            services.AddDbContext<AppDbContext>();

            services.AddAutoMapper(typeof(AutoMapperSetup));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo {Title = "Teste", Version = "v1"});

                // s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                //     Name = "Authorization",
                //     In = ParameterLocation.Header,
                //     Type = SecuritySchemeType.ApiKey,
                //     Scheme = "Bearer"
                // });

                // s.CustomSchemaIds(x => x.FullName);

                // s.AddSecurityRequirement(new OpenApiSecurityRequirement
                // {
                //     {
                //         new OpenApiSecurityScheme
                //         {
                //             Reference = new OpenApiReference
                //             {
                //                 Type = ReferenceType.SecurityScheme,
                //                 Id = "Bearer"
                //             }
                //         },
                //         new string[] { }
                //     }
                // });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(sui => { sui.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"); });
        }
    }
}