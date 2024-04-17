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
        /// Add new track int the collection , check if presence or not in the collection through Id and Name
        /// </summary>
        /// <param name="tr"></param>
        public  void AddTrack(Tracks tr)
        {
            if(!this.Any(TracksInTheCollection=>TracksInTheCollection.Id==tr.Id || TracksInTheCollection.Name==tr.Name))
            {
                this.Add(tr);

            }
            else
            {
                // tracks not added to collection (add of a display message to be added 
                
            }

        }

        public void RemoveTrack(Tracks tr) 
        {
            if(this.Contains(tr))
            {
                this.Remove(tr);
            }

        }

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
