﻿using MixMashter.Model.Artists;
using MixMashter.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.Tracks
{
    public class Mashup : Tracks
    {

        #region Attributs

        private Masher _masher;







        #endregion


        #region Constructeurs

        public Mashup(int id, string name, int length, Artist artist, Band band, string urlpath, bool explicitlyrics) : base(id, name, length, artist, band, urlpath, explicitlyrics)
        {
        }


        #endregion


        #region Props
        public Masher Masher
        {
            get { return _masher; }
            set { _masher = value; }
        }

        #endregion


        #region Methodes



        #endregion



    }
}
