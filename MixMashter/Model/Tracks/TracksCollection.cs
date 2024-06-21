using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.Tracks
{
    public class TracksCollection : ObservableCollection<Tracks>
    {

        public TracksCollection() { }

        /// <summary>
        /// Add new track in the collection , check if presence or not in the collection through Id and Name
        /// </summary>
        /// <param name="tr"></param>
        public bool AddTrack(Tracks trk)
        {
            if (this.Count == 0 || !this.Any(tracksInTheCollection => tracksInTheCollection.Id == trk.Id || (tracksInTheCollection.Name == trk.Name )))
            {
                this.Add(trk);
                return true;
            }
            else
            {
                //if track Id & tName already in the collection , will not be added.
                return false;
            }

        }//End AddArtists

        /// <summary>
        /// Remove a track from the collection 
        /// </summary>
        /// <param name="trk"></param>
        /// <returns></returns>
        public bool RemoveTrack(Tracks trk) 
        {
            if (this.Count != 0 && trk !=null && this.Any(tracksInTheCollection => tracksInTheCollection.Id == trk.Id))
            {
                this.Remove(trk);
                return true;
            }
            else
            {
                
                return false;
            }

        }//End RemoveArtists

        /// <summary>
        /// Determine new next id (max + 1) for a manual AddTrack
        /// </summary>
        /// <returns></returns>
        public int GetNextId()
        {
            if (this != null && this.Count > 1)
            {
                return this.Max(trk => trk.Id) + 1;
            }
            else
            {
                return 1;
            }
        }//End GetNextId()

        /// <summary>
        /// Sort Tracks from the Tracks Collections
        /// </summary>
        public List<Tracks> Tracks => this.OfType<Tracks>().ToList();

        /// <summary>
        /// Sort Mashup from the Tracks Collections
        /// </summary>
        public List<Mashup> Mashup => this.OfType<Mashup>().ToList();


    }
}
