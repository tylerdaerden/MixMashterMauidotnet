using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.Artists
{
    public class Masher : Artist
    {


        #region Attributs

        private string _mashername;

        #endregion



        #region Constructeurs

        public Masher(int id, string artistname, string lastname, string firstname, bool gender , string picturename, string mashername) : base(id, artistname, lastname, firstname, gender , picturename)
        {
            MasherName = mashername;
        }


        #endregion


        #region Props

        //penser à mettre une méthode de vérification sur le name dans tools !!! 
        public string MasherName 
        {
            get => _mashername;
            set => _mashername = value;
        }


        #endregion



        #region Methodes



        #endregion

    }
}
