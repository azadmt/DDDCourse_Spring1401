using AccountManagement.Application;
using AccountManagement.Application.Contract;
using AccountManagement.Domain.BankAccount;
using AccountManagement.Domain.Contract;
using AccountManagement.EventHandlers;
using AccountManagement.Persistence.EF;
using Autofac;
using Framework.Bus.Autofac;
using Framework.Core;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagement.Api
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
            services.AddDbContext<AccountManagementDbContext>(opt => opt.UseInMemoryDatabase("AccountManagementDB"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountManagement.Api", Version = "v1" });
            });

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });

            services.AddMassTransitHostedService();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacBus>().As<Framework.Core.IBus>().InstancePerLifetimeScope();
            builder.RegisterType<BankAccountRepository>().As<IBankAccountRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OpenNewAccountCommandHandler>().As<ICommandHandler<OpenNewAccountCommand>>().InstancePerLifetimeScope();
            builder.RegisterType<AccountCeatedEventHandler>().As<IEventHandler<AccountCratedEvent>>().InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AccountManagement.Api v1"));
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
