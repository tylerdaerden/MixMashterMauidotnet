using MixMashter.Utilities.ToolBox.Checks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.Artists
{
    public class Artist
    {
        #region Attributs

        private int _id;
        private string _artistname;
        private string _lastName;
        private string _firstName;
        private int _gender;

        #endregion

        #region Constructeurs

        public Artist(int id , string artistname , string lastname , string firtsname , int gender  )
        {

        }

        #endregion

        #region Props

        public int Id 
        { 
            get => _id; 
            set => _id = value; 
        }

        public string ArtistName
        {
            get => _artistname;
            set
            {
                if (CheckTools.CheckEntryName(value))
                {
                    _artistname = value;
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (CheckTools.CheckEntryName(value))
                {
                    _lastName = value;
                }
            }
        }

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


        #endregion

        #region Methodes



        #endregion




    }

}
