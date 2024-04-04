using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.User
{
    public class Masher : User
    {


        #region Attributs

        private bool _isMasher;

        #endregion



        #region Constructeurs

        public Masher(int id, string firstName, string lastName, string userName, string email, DateTime birthDate, string password , bool ismasher) : base(id, firstName, lastName, userName, email, birthDate, password)
        {
            IsMasher = ismasher; 

        }

        #endregion


        #region Props

        public bool IsMasher 
        {
            get => _isMasher; 
            set => _isMasher = value ; 
        }


        #endregion



        #region Methodes

        /// <summary>
        /// Méthode d'ajout d'objets Mashups reservée à Masher
        /// </summary>
        public void AddMashupToDatabase()
        {
            // à developper later 
            throw new NotImplementedException();
        }


        #endregion



    }
}
