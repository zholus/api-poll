using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polling.Builders;
using Polling.Db;
using Polling.Db.UoW;
using Polling.Extensions;
using Polling.Providers;
using Polling.Repositories;
using Polling.Security;
using Swashbuckle.AspNetCore.Swagger;

namespace Polling
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDbConnectionStatusChecker, DbConnectionStatusChecker>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IUserBuilder, UserBuilder>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IQuestionBuilder, QuestionBuilder>();
            services.AddScoped<IQuestionsBuilder, QuestionsBuilder>();
            services.AddScoped<IPollModelResponseBuilder, PollModelResponseBuilder>();
            services.AddScoped<IQuestionModelResponseBuilder, QuestionModelResponseBuilder>();
            services.AddScoped<IQuestionsModelResponseBuilder, QuestionsModelResponseBuilder>();
            
            services
                .AddMvc(options => options.Conventions.Insert(0, new ModeRouteConvention()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Polling API documentation", Version = "v1" });
            });

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}