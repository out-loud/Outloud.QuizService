using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Outloud.Common.Swagger;
using Outloud.Common.Authentication;
using Outloud.QuizService.Persistance;
using Microsoft.EntityFrameworkCore;
using Outloud.QuizService.Persistance.Repositiories;
using Outloud.QuizService.Mappers;

namespace Outloud.QuizService
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddDbContext<QuizDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                opt => opt.UseRowNumberForPaging()), ServiceLifetime.Singleton);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();
            services.AddAuth0();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<QuizDbContext>();
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseAuth0();
            app.UseMvc();
        }
    }
}
