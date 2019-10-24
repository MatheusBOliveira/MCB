﻿using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Commands.Users
{
    public class LogoutSessionCommand
        : CommandBase
    {
        public Guid ApplicationId { get; set; }
        public string SessionToken { get; set; }
        public EmailValueObject Email { get; set; }

        public override async Task<bool> IsValid()
        {
            return await Task.FromResult(true);
        }
    }
}
