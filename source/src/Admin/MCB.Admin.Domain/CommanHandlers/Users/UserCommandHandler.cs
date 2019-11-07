using MCB.Admin.Domain.Commands.Users;
using MCB.Admin.Domain.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Base;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.CommandHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.EventHandlers.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Saga.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.CommanHandlers.Users
{
    public class UserCommandHandler
        : CommandHandlerBase,
        ICommandHandler<LoginCommand, ApplicationUserSession>,
        ICommandHandler<LogoutAllSessionsCommand, bool>,
        ICommandHandler<LogoutSessionCommand, bool>
    {
        public UserCommandHandler(
            ISagaManager sagaManager,
            IDomainNotificationHandler domainNotificationHandler
            ) 
            : base(sagaManager, domainNotificationHandler)
        {
        }

        public async Task<CommandReturn<ApplicationUserSession>> Handle(LoginCommand message, ApplicationUserSession returnObject, CancellationToken cancellationToken = default)
        {
            var comandReturn = new CommandReturn<ApplicationUserSession>(returnObject);



            return await Task.FromResult(comandReturn);
        }
        public async Task<CommandReturn<bool>> Handle(LogoutAllSessionsCommand message, bool returnObject, CancellationToken cancellationToken = default)
        {
            var comandReturn = new CommandReturn<bool>(returnObject);



            return await Task.FromResult(comandReturn);
        }
        public async Task<CommandReturn<bool>> Handle(LogoutSessionCommand message, bool returnObject, CancellationToken cancellationToken = default)
        {
            var comandReturn = new CommandReturn<bool>(returnObject);



            return await Task.FromResult(comandReturn);
        }
    }
}
