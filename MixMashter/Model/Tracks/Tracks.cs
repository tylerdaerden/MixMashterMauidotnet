using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MixMashter.Model.Artists;
using MixMashter.Utilities.ToolBox.Checks;

namespace MixMashter.Model.Tracks
{
    public class Tracks : INotifyPropertyChanged
    {
        //implémentation INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Attributs

        private int _id;
        private string _name;
        private int _length;
        private string _artistName; 
        private string _urlpath;
        private bool _explicitlyrics;
        private string _pictureName; 

        #endregion

        #region Constructeurs

        public Tracks(int id, string name, int length, string artistName, string urlpath, bool explicitlyrics, string pictureName)
        {
            Id = id;
            Name = name;
            Length = length;
            ArtistName = artistName;
            Urlpath = urlpath;
            Explicit = explicitlyrics;
            PictureName = pictureName;
        }

        #endregion

        #region Props

        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public int Length
        {
            get => _length;
            set
            {
                if (CheckTools.CheckTrackLength(value))
                {
                    _length = value;
                }
                OnPropertyChanged(nameof(Length));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if(CheckTools.CheckNameMin1Char(value))
                {
                    _name = value;
                }
                OnPropertyChanged(nameof(Name));
            }
        }
        public string ArtistName
        {
            get => _artistName;
            set
            {
                if(CheckTools.CheckNameMin1Char(value))
                {
                    _artistName = value;
                }
                OnPropertyChanged(nameof(ArtistName));
            }
        }
        public string Urlpath
        {
            get => _urlpath;
            set
            {
                if(CheckTools.CheckUrl(value))
                {
                    _urlpath = value;
                }
                OnPropertyChanged(nameof(Urlpath));
            }
        }
        public bool Explicit
        {
            get => _explicitlyrics;
            set => _explicitlyrics = value;
        }

        public string PictureName
        {
            get => _pictureName;
            set
            {
                if (CheckTools.CheckPicture(value))
                {
                    _pictureName = value;
                }
                OnPropertyChanged(nameof(PictureName));
            }
        }



        #endregion

        #region Méthodes

        /// <summary>
        /// Implémentation méthode OnPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Méthode pour récupérer l'artiste correspondant
        //public Artist GetTrackArtist()
        //{
        //    return Artist.GetArtistByName(ArtistName);
        //} 

        #endregion


    }
}
