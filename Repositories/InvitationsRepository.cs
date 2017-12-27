using Commentifier.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace Commentifier.Repositories
{
    public class InvitationsRepository : BaseRepository<Invitation>, IInvitationsRepository
    {
        public InvitationsRepository(CommentifierContext _context) : base(_context) { }

        public string AddWithValidation(Invitation invitaiton)
        {
            if (_context.Invitations.Any(i => i.Email == invitaiton.Email))
                return INVITATION_RESPONSES["exists"];
            else
            {
                _context.Invitations.Add(invitaiton);
                _context.SaveChanges();
                return INVITATION_RESPONSES["success"];
            }
        }

        static NameValueCollection INVITATION_RESPONSES = new NameValueCollection()
        {
            { "exists", "Ваша почтовый адрес уже был зарегистрирован." },
            { "success", "Спасибо за регистрацию." }
        };
    }
}
