using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Invitations.UseCases
{
    public class SendInvitesUseCase : IUseCase<InvitationInput>
    {
        private readonly DbContext _context;
        private readonly IInvitationFactory _invitationsFactory;
        private readonly IEmailService _emailService;

        public SendInvitesUseCase(DbContext context, IInvitationFactory invitationsFactory, IEmailService emailService)
        {
            _context = context;
            _invitationsFactory = invitationsFactory;
            _emailService = emailService;
        }

        public void Execute(InvitationInput input)
        {
            _emailService.SendEmail("Bla", input.Emails, "Hej");
            input.Emails.ForEach((email) =>
            {
                _context.Add(_invitationsFactory.CreateInvite(email, input.EventId));
            });
            _context.SaveChanges();
        }
    }
}
