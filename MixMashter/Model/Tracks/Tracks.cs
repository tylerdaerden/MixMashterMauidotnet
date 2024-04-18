using System;
using MixMashter.Model.Artists;

namespace MixMashter.Model.Tracks
{
    public class Tracks
    {
        private int _id;
        private string _name;
        private int _length;
        private string _artistName; // Nom de l'artiste en tant que chaîne de caractères pour gérer CSV et JSON
        private string _urlpath;
        private bool _explicitlyrics;

        public Tracks(int id, string name, int length, string artistName, string urlpath, bool explicitlyrics)
        {
            Id = id;
            Name = name;
            Length = length;
            ArtistName = artistName; 
            Urlpath = urlpath;
            Explicit = explicitlyrics;
        }

        public int Id 
        { 
            get => _id;
            set => _id = value; 
        }
        public int Length 
        { 
            get => _length; 
            set => _length = value; 
        }
        public string Name 
        {
            get => _name;
            set => _name = value; 
        }
        public string ArtistName 
        { 
            get => _artistName; 
            set => _artistName = value; 
        } 
        public string Urlpath 
        { 
            get => _urlpath;
            set => _urlpath = value; 
        }
        public bool Explicit
        {
            get => _explicitlyrics;
            set => _explicitlyrics = value; 
        }

        // Méthode pour récupérer l'artiste correspondant
        //public Artist GetTrackArtist()
        //{
        //    return Artist.GetArtistByName(ArtistName);
        //}
    }
}
