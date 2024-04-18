using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.User
{
    internal class Admin : User
    {

        #region Attributs

        private bool _isAdmin;


        #endregion



        #region Constructeurs

        public Admin(int id, string firstName, string lastName, string userName, int gender, string email, DateTime birthDate, string password, bool isadmin) : base(id, firstName, lastName, userName, gender, email, birthDate, password)
        {

            IsAdmin = isadmin;


        }

        #endregion

        #region Props

        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
 

                    _isAdmin = true;

 
            }
        }



        #endregion


        #region Fonctions

        /// <summary>
        /// Fonction Admin de suppresion de User
        /// </summary>
        /// <param name="user"></param>

        public static void DeleteUser(User user)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Fonction Admin de Création d'admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>

        public static bool UpdateAdminStatus(Admin admin)
        {
            if (admin._isAdmin == true)
            {
                return true;
            }
            //A Implementer
            return false;
        }



        #endregion



    }
}
