using Commentifier.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentifier.Models
{
    public class Invitation : IEntityBase
    {
        public int ID { get; set; }
        public string Email { get; set; }
    }
}
