using Android.App;
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

        public string FirstName 
        { 
            get => _firstName;
            set
            {
                if (Tools.CheckEntryName(value))
                {
                    _firstName = value;
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if(Tools.CheckEntryName(value))
                _lastName = value; 
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (Tools.CheckEntryName(value))
                {
                    _userName = value;
                }
            }
        }

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

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                //if(insérer ici méthode de vérification date pour mettre un age minimal de 13 ans)
                {
                    _birthDate = value;
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                //if( Tools.CheckPassword(value) ) trouver méthode préliminaire de vérification Password, genre minimum 12 caractère)
                {
                    _password = value;
                }

            }
        }

        #endregion


        #region Constructeurs

        public User(int id, string firstName, string lastName, string userName, string email, DateTime birthDate, string password)
        {
            Id = _id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
        }


        #endregion


        #region Fonctions

        //méthodes à créer plus tard toutes définies en Bool return true temporairement 
        public bool Login()
        {
            return true;
        }

        public bool Register() 
        {
            return true;
        }

        public bool UnSubscribe() 
        {
            return true;
        }

        public bool UpdateInfos() 
        {
            return true;
        }


        #endregion


    }//end class



}//end namespace
