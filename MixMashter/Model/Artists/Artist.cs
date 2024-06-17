using MixMashter.Utilities.ToolBox.Checks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MixMashter.Model.Artists
{
    public class Artist : INotifyPropertyChanged
    {
        //implémentation INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _id;
        private string _artistName;
        private string _lastName;
        private string _firstName;
        private bool _gender;
        private string _pictureName;

        public Artist(int id, string artistname, string lastname, string firstname, bool gender , string picturename)
        {
            Id = id;
            ArtistName = artistname;
            LastName = lastname;
            FirstName = firstname;
            Gender = gender;
            PictureName = picturename;
        }

        public int Id 
        { 
            get => _id; 
            set => _id = value; 
        
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

        public string LastName 
        { 
            get => _lastName;
            set
            {
                if(CheckTools.CheckNameMin1Char(value))
                {
                    _lastName = value;
                }
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string FirstName 
        { 
            get => _firstName;
            set
            {
                if(CheckTools.CheckNameMin1Char(value))
                {
                    _firstName = value;
                }
                OnPropertyChanged(nameof(FirstName));

            }
        }

        public bool Gender 
        { 
            get => _gender; 
            set => _gender = value; 
            
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




        // Méthode pour rechercher et renvoyer l'objet Artist correspondant à partir du nom de l'artiste
        public static Artist GetArtistByName(string artistName)
        {
            // Logique de recherche et renvoi de l'artiste correspondant, à implémenter quand DB présente peut être ? 
            // Retourner null si aucun artiste correspondant n'est trouvé
            throw new NotImplementedException();
            //return null;
        }

        /// <summary>
        /// Implémentation méthode OnPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
