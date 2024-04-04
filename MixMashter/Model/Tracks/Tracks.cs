using MixMashter.Model.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.Tracks
{
    public class Tracks
    {

        #region Attributs

        private int _id;
        private string _name;
        private int _length;
        private Artist _artist;
        private Band _band;
        private bool _explicitlyrics;

        #endregion

        #region Constructeurs

        public Tracks(int id , string name , int length , Artist artist   , Band band , bool explicitlyrics )  
        {
            Id = id ;
            Name = name ;
            Length = length ;
            Artist = artist ;
            Band = band ;
            Explicit = explicitlyrics ;

        }

        #endregion

        #region Props

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }        
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Artist Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        public Band Band
        {
            get { return _band; }
            set { _band = value; }
        }
        public Boolean Explicit
        {
            get { return _explicitlyrics; }
            set { _explicitlyrics = value; }
        }

        #endregion


        #region Methodes



        #endregion


    }




}

