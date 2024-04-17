//using Android.App;
using MixMashter.Utilities.ToolBox.Checks;
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
        private int _gender;
        private string _email;
        private DateTime _birthDate;
        private string _password;
        //private bool _isAdult;

        #endregion

        #region Constructeurs


        public User(int id, string firstName, string lastName, string userName, int gender, string email, DateTime birthDate, string password)//ajouter is adult en prop
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Gender = gender;
            Email = email;
            BirthDate = birthDate;
            Password = password;

        }


        #endregion

        #region Props


        public int Id { get => _id; set => _id = value; }

        public string FirstName 
        { 
            get => _firstName;
            set
            {
                if (CheckTools.CheckEntryName(value))
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
                if(CheckTools.CheckEntryName(value))
                _lastName = value; 
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (CheckTools.CheckEntryName(value))
                {
                    _userName = value;
                }
            }
        }

        public int Gender 
        { 
            get => _gender;
            set
            {
                if(CheckTools.CheckGender(value))
                {
                    _gender = value;
                }
            }
        }

        public string Email 
        {
            get => _email;
            set
            {
                if (CheckTools.CheckEMail(value))
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
                // Calcul de l'âge de l'utilisateur
                int age = DateTime.Today.Year - value.Year;

                // Vérification de l'âge minimal
                if (age < 13 || (age == 13 && value.Date > DateTime.Today.AddYears(-13)))
                {
                    throw new ArgumentException("L'utilisateur doit avoir au moins 13 ans.");
                }

                _birthDate = value;
            }
        }



        public string Password
        {
            get => _password;
            set
            {
                if (CheckTools.CheckPassword(value)) 
                {
                    _password = value;
                }

            }
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
