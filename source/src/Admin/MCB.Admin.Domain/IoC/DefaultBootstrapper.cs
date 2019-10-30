using MCB.Admin.Domain.Adapters.Events;
using MCB.Admin.Domain.Adapters.Events.Interfaces;
using MCB.Admin.Domain.Commands.Customers;
using MCB.Admin.Domain.Commands.Users;
using MCB.Admin.Domain.CommanHandlers.Customers;
using MCB.Admin.Domain.CommanHandlers.Users;
using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels;
using MCB.Admin.Domain.Factories.DomainModels.Interfaces;
using MCB.Admin.Domain.Factories.Events.Customers;
using MCB.Admin.Domain.Factories.Events.Customers.Interfaces;
using MCB.Admin.Domain.Factories.Queries.Customers;
using MCB.Admin.Domain.Factories.Queries.Customers.Interfaces;
using MCB.Admin.Domain.Queries.Applications;
using MCB.Admin.Domain.Queries.Customers;
using MCB.Admin.Domain.Queries.Users;
using MCB.Admin.Domain.QueryHandlers.Applications;
using MCB.Admin.Domain.QueryHandlers.Customers;
using MCB.Admin.Domain.QueryHandlers.Users;
using MCB.Admin.Domain.Validations.Commands.Customers.ActiveCustomerCommands;
using MCB.Admin.Domain.Validations.Commands.Customers.ActiveCustomerCommands.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.QueryHandlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.IoC
{
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            Core.Infra.CrossCutting.Security.IoC.DefaultBootstrapper.RegisterServices(services);
            Core.Infra.CrossCutting.Patterns.IoC.DefaultBootstrapper.RegisterServices(services);
            Core.Domain.IoC.DefaultBootstrapper.RegisterServices(services);

            RegisterAdapters(services);
            RegisterCommandHandlers(services);
            RegisterFactories(services);
            RegisterQueryHandlers(services);
            RegisterSpecifications(services);
            RegisterValidations(services);
        }

        private static void RegisterAdapters(IServiceCollection services)
        {
            services.AddScoped<ICustomerActivationFailEventAdapter, CustomerActivationFailEventAdapter>();
        }
        private static void RegisterCommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<ActiveCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<ICommandHandler<InactiveCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<ICommandHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            services.AddScoped<ICommandHandler<LoginCommand, ApplicationUserSession>, UserCommandHandler>();
            services.AddScoped<ICommandHandler<LogoutAllSessionsCommand, bool>, UserCommandHandler>();
            services.AddScoped<ICommandHandler<LogoutSessionCommand, bool>, UserCommandHandler>();
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            // Factories - DomainModels
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            // Factories - Events
            services.AddScoped<ICustomerActivatedEventFactory, CustomerActivatedEventFactory>();
            services.AddScoped<ICustomerActivationFailEventFactory, CustomerActivationFailEventFactory>();
            // Factories - Queries
            services.AddScoped<ICheckIfEmailExistsInRepositoryQueryFactory, CheckIfEmailExistsInRepositoryQueryFactory>();

        }

        private static void RegisterQueryHandlers(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetApplicationsByCustomerEmailAddressQuery, List<Application>>, ApplicationQueryHandler>();

            services.AddScoped<IQueryHandler<GetAllCustomersQuery, List<Customer>>, CustomerQueryHandler>();
            services.AddScoped<IQueryHandler<GetCustomerByEmailAddressQuery, Customer>, CustomerQueryHandler>();
            services.AddScoped<IQueryHandler<GetCustomersByNameQuery, List<Customer>>, CustomerQueryHandler>();

            services.AddScoped<IQueryHandler<GetApplicationUserAccessesInApplicationQuery, List<ApplicationUser>>, UserQueryHandler>();
            services.AddScoped<IQueryHandler<GetApplicationUsersByAppTokenQuery, List<ApplicationUser>>, UserQueryHandler>();
        }

        private static void RegisterSpecifications(IServiceCollection services)
        {
            // Customers
            services.AddScoped<Specifications.Commands.Customers.Base.Interfaces.IEmailMustExistsInRepositorySpecification, Specifications.Commands.Customers.Base.EmailMustExistsInRepositorySpecification>();
            services.AddScoped<Specifications.Commands.Customers.Base.Interfaces.IEmailMustNotExistsInRepositorySpecification, Specifications.Commands.Customers.Base.EmailMustNotExistsInRepositorySpecification>();
            services.AddScoped<Specifications.Commands.Customers.ActiveCustomerCommands.Interfaces.IEmailIsRequiredSpecification, Specifications.Commands.Customers.ActiveCustomerCommands.EmailIsRequiredSpecification>();

        }

        private static void RegisterValidations(IServiceCollection services)
        {
            // Customer
            services.AddScoped<Validations.Commands.Customers.Base.Interfaces.IEmailMustExistInRepositoryValidator, Validations.Commands.Customers.Base.EmailMustExistInRepositoryValidator>();
            services.AddScoped<Validations.Commands.Customers.Base.Interfaces.IEmailMustNotExistInRepositoryValidator, Validations.Commands.Customers.Base.EmailMustNotExistInRepositoryValidator>();
            services.AddScoped<IActiveCustomerCommandValidator, ActiveCustomerCommandValidator>();
        }
    }
}
