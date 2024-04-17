using MixMashter.ToolBox;
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

        public Artist(int id, string artistname, string lastname, string firstname, int gender = 0)
        {
            Id = id;
            ArtistName = artistname;
            LastName = lastname;
            FirstName = firstname;
            Gender = gender;
        }

        #endregion

        #region Props
        /// <summary>
        /// Id number
        /// </summary>
        public int Id { get => _id; set => _id = value; }

        public string ArtistName
        {
            get => _artistname;
            set               
            {
                if (Tools.CheckEntryName(value))
                {
                    _artistname = value;
                }

            }
        }

        /// <summary>
        /// Personal Last Name
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                if (Tools.CheckEntryName(value))
                {
                    _lastName = value;
                }
            }
        }
        /// <summary>
        /// Personal First Name
        /// </summary>
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
        /// <summary>
        /// Gender : 0 = Non Specified , 1 = Female , 2 = Male
        /// </summary>
        public int Gender
        {
            get => _gender;
            set 
            {
                if (Tools.CheckGenderPlus(value))
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
