using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.User
{
    internal class Masher : User
    {
        public Masher(int id, string firstName, string lastName, string userName, string email, DateTime birthDate, string password) : base(id, firstName, lastName, userName, email, birthDate, password)
        {

        }
    }
}
