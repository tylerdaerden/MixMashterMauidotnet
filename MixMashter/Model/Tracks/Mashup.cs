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

        // !!! Temporairement conversion des 2 attributs suivant en string pour débloquer , revenir dessus later maybe 
        //private List<Artist> _originalartists;
        //private Masher _masher;
        //Modifications en string des attributs anciens ↑↑↑ ci dessous ↓↓↓
        private string _originalartists;
        private string _masher;

        #endregion


        #region Constructeurs


        // !!! Ancien Constructeur avec type Masher et List<Artists> REVENIR DESSUS LATER ! 
        //public Mashup(int id, string name, int length, string artist, /*Band band,*/ string urlpath, bool explicitlyrics, string pictureName, List<Artist> originalartists, Masher masher) : base(id, name, length, artist,/* band,*/ urlpath, explicitlyrics , pictureName)
        //{
        //    OriginalArtists = originalartists;
        //    Masher = masher;
        //}

        public Mashup(int id, string name, int length, string artistname, /*Band band,*/ string urlpath, bool explicitlyrics, string pictureName, string originalartists, string masher) : base(id, name, length, artistname,/* band,*/ urlpath, explicitlyrics, pictureName)
        {
            OriginalArtists = originalartists;
            Masher = masher;
        }

        #endregion


        #region Props
        // public Masher Masher 
        // modification en string ↓↓↓
        public string Masher
        {
            get  => _masher; 
            set  => _masher = value; 
        }

        //public List<Artist> OriginalArtists 
        // modification en string ↓↓↓
        public string OriginalArtists 
        { 
            get => _originalartists; 
            set => _originalartists=value ; 
        }

        #endregion


        #region Methodes



        #endregion



    }
}
