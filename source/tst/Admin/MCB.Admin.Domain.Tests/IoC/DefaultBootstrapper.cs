using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.Commands.Users;
using MCB.Admin.Domain.CommanHandlers.Customers;
using MCB.Admin.Domain.CommanHandlers.Users;
using MCB.Admin.Domain.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Tests.IoC
{
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            Domain.IoC.DefaultBootstrapper.RegisterServices(services);
        }
    }
}
