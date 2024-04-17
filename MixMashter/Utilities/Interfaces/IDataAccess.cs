using MixMashter.Model.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Utilities.Interfaces
{
    public interface IDataAccess
    {
        /// <summary>
        /// Access string to external source (file path connection string)
        /// </summary>
        string AccessPath
        {
            get;
            set;
        }

        /// <summary>
        /// Get all Tracks informations from an external source 
        /// </summary>
        /// <returns> TracksCollection</returns>
        TracksCollection GetAllTracks();


        /// <summary>
        /// Get a trackpath URL from an external source
        /// </summary>
        /// <returns> TracksCollection.Path</returns>
        TracksCollection GetTrackPath();









    }
}
