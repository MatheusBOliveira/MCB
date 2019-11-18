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
using MCB.Admin.Domain.Services;
using MCB.Admin.Domain.Services.Interfaces;
using MCB.Admin.Domain.Specifications.Customers;
using MCB.Admin.Domain.Specifications.Customers.Interfaces;
using MCB.Admin.Domain.Validations.Applications;
using MCB.Admin.Domain.Validations.Applications.Interfaces;
using MCB.Admin.Domain.Validations.Customers;
using MCB.Admin.Domain.Validations.Customers.Interfaces;
using MCB.Admin.Domain.Validations.Users;
using MCB.Admin.Domain.Validations.Users.Interfaces;
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
            RegisterDomainServices(services);
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
            services.AddScoped<IApplicationFactory, ApplicationFactory>();
            services.AddScoped<IApplicationFunctionFactory, ApplicationFunctionFactory>();
            services.AddScoped<IApplicationRoleFactory, ApplicationRoleFactory>();
            services.AddScoped<IApplicationUserFactory, ApplicationUserFactory>();
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<IUserFactory, UserFactory>();
            // Factories - Events
            services.AddScoped<ICustomerActivatedEventFactory, CustomerActivatedEventFactory>();
            services.AddScoped<ICustomerActivationFailEventFactory, CustomerActivationFailEventFactory>();
            services.AddScoped<ICustomerRegistrationFailEventFactory, CustomerRegistrationFailEventFactory>();
            services.AddScoped<ICustomerRegistrationSuccessfulEventFactory, CustomerRegistrationSuccessfulEventFactory>();
            // Factories - Queries
            services.AddScoped<ICheckIfEmailExistsInRepositoryQueryFactory, CheckIfEmailExistsInRepositoryQueryFactory>();
            services.AddScoped<IGetCustomerByEmailAddressQueryFactory, GetCustomerByEmailAddressQueryFactory>();
            services.AddScoped<IGetCustomerByIdQueryFactory, GetCustomerByIdQueryFactory>();
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
            services.AddScoped<ICustomerEmailIsRequiredSpecification, CustomerEmailIsRequiredSpecification>();
            services.AddScoped<ICustomerEmailMustBeUniqueInRepositorySpecification, CustomerEmailMustBeUniqueInRepositorySpecification>();
            services.AddScoped<ICustomerGovernamentalDocumentNumberIsRequiredSpecification, CustomerGovernamentalDocumentNumberIsRequiredSpecification>();
            services.AddScoped<ICustomerGovernamentalNumberForLegalPersonIsValidSpecification, CustomerGovernamentalNumberForLegalPersonIsValidSpecification>();
            services.AddScoped<ICustomerGovernamentalNumberForNaturalPersonIsValidSpecification, CustomerGovernamentalNumberForNaturalPersonIsValidSpecification>();
            services.AddScoped<ICustomerIdIsRequiredSpecification, CustomerIdIsRequiredSpecification>();
            services.AddScoped<ICustomerMustBeActiveInRepositorySpecification, CustomerMustBeActiveInRepositorySpecification>();
            services.AddScoped<ICustomerMustBeActiveSpecification, CustomerMustBeActiveSpecification>();
            services.AddScoped<ICustomerMustBeInactiveInRepositorySpecification, CustomerMustBeInactiveInRepositorySpecification>();
            services.AddScoped<ICustomerMustBeInactiveSpecification, CustomerMustBeInactiveSpecification>();
            services.AddScoped<ICustomerMustBeLegalPersonSpecification, CustomerMustBeLegalPersonSpecification>();
            services.AddScoped<ICustomerMustBeNaturalPersonSpecification, CustomerMustBeNaturalPersonSpecification>();
            services.AddScoped<ICustomerMustExistsInRepositorySpecification, CustomerMustExistsInRepositorySpecification>();
            services.AddScoped<ICustomerMustNotExistsInRepositorySpecification, CustomerMustNotExistsInRepositorySpecification>();
            services.AddScoped<ICustomerNameIsRequiredSpecification, CustomerNameIsRequiredSpecification>();
            services.AddScoped<ICustomerNameValidLengthSpecification, CustomerNameValidLengthSpecification>();
            services.AddScoped<ICustomerPhoneNumberIsRequiredSpecification, CustomerPhoneNumberIsRequiredSpecification>();

        }

        private static void RegisterValidations(IServiceCollection services)
        {
            services.AddScoped<IApplicationIsValidForRegistrationValidation, ApplicationIsValidForRegistrationValidation>();
            services.AddScoped<ICustomerIsValidForRegistrationValidation, CustomerIsValidForRegistrationValidation>();
            services.AddScoped<IUserIsValidForRegistrationValidation, UserIsValidForRegistrationValidation>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddSingleton<IApplicationService, ApplicationService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
