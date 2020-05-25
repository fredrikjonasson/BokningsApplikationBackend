using Domain.Invitations;
using System;

namespace Infrastructure.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly EventContext _context;

        public InvitationRepository(EventContext context)
        {
            _context = context;
        }

        public IInvitation GetById(Guid id)
        {
            return _context.Find<Entities.Invitation>(id);
        }
    }
}
