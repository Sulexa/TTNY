using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TwitchGames.Ttny.Api.Consumers;
using TwitchGames.Ttny.Dal.Entities;

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

            //services.AddUnitOfWorkServices<UserDbContext>();

            services.AddDbContext<TtnyDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            //services.AddMediatR(typeof(AddOrUpdateTwitchUserHandler).Assembly);
            services.AddMassTransit(x =>
            {
                //x.AddConsumer<AddOrUpdateTwitchUserConsumer>();
                x.AddConsumer<AddOrUpdateUserConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration.GetConnectionString("RabbitMq"));

                    cfg.ReceiveEndpoint("add-or-update-user-listener", e =>
                    {
                        e.ConfigureConsumer<AddOrUpdateUserConsumer>(context);
                    });
                });

                //x.AddRequestClient<AddOrUpdateTwitchUser>();

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
