using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Invitations.UseCases
{
    public class ReplyUseCase : IUseCase<IInvitation>
    {
        public DbContext _eventContext { get; set; }

        public ReplyUseCase(DbContext eventContext)
        {
            _eventContext = eventContext;
        }

        public void Execute(IInvitation invitation)
        {

        }
    }
}
