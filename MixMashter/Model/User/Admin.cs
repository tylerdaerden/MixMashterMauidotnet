using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.User
{
    internal class Admin : User
    {
        public Admin(int id, string firstName, string lastName, string userName, string email, DateTime birthDate, string password) : base(id, firstName, lastName, userName, email, birthDate, password)
        {



        }
    }
}
