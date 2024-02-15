using MixMashter.ToolBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.User
{
    public class User
    {


        #region Attributs

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private DateTime _birthDate;
        private string _password;

        #endregion

        #region Props

        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Email 
        {
            get => _email;
            set
            {
                if (Tools.CheckEMail(value))
                {
                    _email = value;
                }
            } 
        }


        public DateTime BirthDate //ici faire vérification sur âge pour mettre un age minimal de 13 ans 
        {
            get => _birthDate;
            set
            {
                //if(//insérer ici méthode de vérificaion date)
                {
                    _birthDate = value;
                }

            }
        }
        public string Password { get => _password; set => _password = value; } 

        #endregion













    }
}
