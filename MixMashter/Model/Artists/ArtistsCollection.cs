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

        /// <summary>
        /// Add new Artist in the Collection , check made before on ID
        /// </summary>
        /// <param name="art"></param>
        public void AddArtist(Artist art)
        {
            if(!this.Any(ArtistInTheCollection=>ArtistInTheCollection.Id==art.Id))
            {
                this.Add(art);
            }
            else
            {

            }
        }

        /// <summary>
        /// remove an Artists from the collection 
        /// </summary>
        /// <param name="art"></param>
        public void RemoveArtist(Artist art) 
        {
            if(this.Contains(art)) 
            { 
                this.Remove(art); 
            }
        }



    }
}
