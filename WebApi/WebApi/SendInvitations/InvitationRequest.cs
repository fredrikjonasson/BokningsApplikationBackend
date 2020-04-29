using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.SendInvitations
{
    public class InvitationRequest
    {
        public List<string> Emails { get; set; }
    }
}
