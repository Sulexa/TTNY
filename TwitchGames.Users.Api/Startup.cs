using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TwitchGames.Shared.UnitOfWorkLibrary.Extensions;
using TwitchGames.Users.Api.Consumers;
using TwitchGames.Users.Dal.Entities;
using TwitchGames.Users.Dal.Interfaces;
using TwitchGames.Users.Dal.Repositories;
using TwitchGames.Users.Domain.RequestHandler;

namespace TwitchGames.Users.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TwitchGames.Users.Api", Version = "v1" });
            });
            services.AddUnitOfWorkServices<UserDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<UserDbContext>(
                options => options.UseSqlite(Configuration.GetConnectionString("Sqlite")));

            services.AddMediatR(typeof(AddTwitchUserHandler).Assembly);
            services.AddMassTransit(x =>
            {
                x.AddConsumer<AddTwitchUserConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("add-twitch-user-listener", e =>
                    {
                        e.ConfigureConsumer<AddTwitchUserConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserDbContext userDbContext)
        {
            // migrate any database changes on startup (includes initial db creation)
            userDbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TwitchGames.Users.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
