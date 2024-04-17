using MixMashter.Model.Artists;
using MixMashter.Model.User;
using System.Collections.ObjectModel;
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
        private List<Artist> _originalartists;


        #endregion


        #region Constructeurs

        public Mashup(int id, string name, int length, Artist artist, /*Band band,*/ string urlpath, bool explicitlyrics, List<Artist> originalartists, Masher masher) : base(id, name, length, artist,/* band,*/ urlpath, explicitlyrics)
        {
            Masher = masher;

            OriginalArtists = originalartists;
        }

        #endregion


        #region Props
        public Masher Masher
        {
            get  => _masher; 
            set  => _masher = value; 
        }

        public List<Artist> OriginalArtists 
        { 
            get => _originalartists; 
            set => _originalartists=value ; 
        }

        #endregion


        #region Methodes



        #endregion



    }
}
