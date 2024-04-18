using MixMashter.Utilities.ToolBox.Checks;
using System.Collections.Generic;

namespace MixMashter.Model.Artists
{
    public class Artist
    {
        private int _id;
        private string _artistName;
        private string _lastName;
        private string _firstName;
        private int _gender;

        public Artist(int id, string artistName, string lastName, string firstName, int gender)
        {
            Id = id;
            ArtistName = artistName;
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
        }

        public int Id 
        { 
            get => _id; 
            set => _id = value; 
        
        }
        public string ArtistName 
        { 
            get => _artistName; 
            set => _artistName = value; 
        }

        public string LastName 
        { 
            get => _lastName;
            set => _lastName = value; 
        }

        public string FirstName 
        { 
            get => _firstName;
            set => _firstName = value; 
        }

        public int Gender 
        { 
            get => _gender; 
            set => _gender = value; 
        }

        // Méthode pour rechercher et renvoyer l'objet Artist correspondant à partir du nom de l'artiste
        public static Artist GetArtistByName(string artistName)
        {
            // Logique de recherche et renvoi de l'artiste correspondant, à implémenter quand DB présente peut être ? 
            // Retourner null si aucun artiste correspondant n'est trouvé
            throw new NotImplementedException();
            //return null;
        }
    }
}
