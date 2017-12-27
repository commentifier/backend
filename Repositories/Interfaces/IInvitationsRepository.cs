using Commentifier.Models;
using Commentifier.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentifier.Repositories
{
    public interface IInvitationsRepository : IBaseRepository<Invitation>
    {
        string AddWithValidation(Invitation invitaiton);
    }
}
