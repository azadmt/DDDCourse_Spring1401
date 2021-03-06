using CustomerManagement.Domain.Contract;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReadModel.DAL;
using ReadModel.EventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModel
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
            services.AddDbContext<ReadModelDbContext>(opt => opt.UseInMemoryDatabase("ReadModelDb"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReadModel", Version = "v1" });
            });


            services.AddMassTransit(x =>
            {
                //// TODO: Auto Register Consumers
                x.AddConsumer<AccountCreatedEventHandler>();
                x.AddConsumer<CustomerCreatedEventHandler>();
                // x.UsingRabbitMq();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint(nameof(AccountCreatedEventHandler), e =>
                    {
                        e.ConfigureConsumer<AccountCreatedEventHandler>(context);                        
                    });

                    
                    cfg.ReceiveEndpoint(nameof(CustomerCreatedEventHandler), e =>
                    {
                        e.ConfigureConsumer<CustomerCreatedEventHandler>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReadModel v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
