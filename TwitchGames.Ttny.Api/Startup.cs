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
using TwitchGames.Ttny.Api.Consumers;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Extensions;
using TwitchGames.Ttny.Domain.RequestHandler;

namespace TwitchGames.Ttny.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TwitchGames.Ttny.Api", Version = "v1" });
            });


            services.AddDbContext<TtnyDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddUnitOfWorkServices<TtnyDbContext>();
            services.AddRepositories();

            services.AddMediatR(typeof(AttackCommandHandler).Assembly);

            services.AddMassTransit(x =>
            {
                x.AddConsumer<AddOrUpdateUserConsumer>();
                x.AddConsumer<CollectConsumer>();
                x.AddConsumer<JoinTownConsumer>();
                x.AddConsumer<UpgradeDefenseConsumer>();

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                    cfg.Host(Configuration.GetConnectionString("RabbitMq"));
                });
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TtnyDbContext ttnyDbContext)
        {
            // migrate any database changes on startup (includes initial db creation)
            ttnyDbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TwitchGames.Ttny.Api v1"));
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
