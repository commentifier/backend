using Commentifier.Models;
using Commentifier.Repositories;
using Commentifier.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commentifier
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
            services.AddDbContext<CommentifierContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IInvitationsRepository, InvitationsRepository>();
            services.AddCors();
            services.AddMvc();
            services.AddScoped<IUpdateService, UpdateService>();
            services.AddSingleton<IBotService, BotService>();
            services.AddSingleton(Configuration.GetSection("BotConfiguration").Get<BotConfiguration>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(builder =>
                builder.AllowCredentials()
                       .WithMethods("GET", "POST", "OPTIONS")
                       .WithHeaders("Content-Type", "Content-Length", "Accept-Encoding", "X-CSRF-Token")
                       .WithExposedHeaders("AMP-Access-Control-Allow-Source-Origin")
                       .WithOrigins("http://localhost"));
            app.UseMvc();
        }
    }
}
