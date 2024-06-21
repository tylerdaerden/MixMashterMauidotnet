using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.Artists
{
    public class ArtistsCollection : ObservableCollection<Artist>
    {
        public ArtistsCollection() { }

       
        public bool AddArtist(Artist art)
        {
            if (this.Count == 0 || !this.Any(artistInTheCollection => artistInTheCollection.Id == art.Id || (artistInTheCollection.LastName == art.LastName && artistInTheCollection.FirstName == art.FirstName)))
            {
                this.Add(art);
                return true;
            }
            else
            {
               
                return false;
            }
        }//end AddArtists

        /// <summary>
        /// remove an Artists from the collection 
        /// </summary>
        /// <param name="art"></param>
        public bool RemoveArtist(Artist art) 
        {
            if (this.Count != 0 && art != null && this.Any(artistInTheCollection => artistInTheCollection.Id == art.Id))
            {
                this.Remove(art);
                return true;

            }
            else
            {
                //if Artist not in the collection 
                return false;
            }
        }//End RemoveArtists

        /// <summary>
        /// Determine new next id (max + 1) for a manual Addartist
        /// </summary>
        /// <returns></returns>
        public int GetNextId()
        {
            if (this != null && this.Count > 1)
            {
                return this.Max(art => art.Id) + 1;
            }
            else
            {
                return 1;
            }
        }//End GetNextId()

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
