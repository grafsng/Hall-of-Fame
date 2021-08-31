using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hall_of_Fame.Models.Context;
using Hall_of_Fame.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hall_of_Fame
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            ///�������� ������ ����������� �� ����� ������������
            string connection = Configuration.GetConnectionString("DefaultConnection");
            ///������������� �������� ������
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));
            ///���������� ���������������� �����������
            services.AddControllers();
            ///����������� �������
            services.AddScoped<IApplicationService, ApplicationService>();
            ///����������� ��������
            services.AddSwaggerGen();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /// Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            /// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            /// specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hall of Fame");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); /// ���������� ������������� �� ����������
            });
        }
    }
}
