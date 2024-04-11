using MixMashter.Model.Tracks;
using MixMashter.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Utilities.DataAccess
{
    public abstract class DataAccess : IDataAccess
    {
        private string _accessPath;
        /// <summary>
        /// constructor with just the filename for accesspath
        /// </summary>
        /// <param name="filePath"></param>
        public DataAccess(string filePath)
        {
            _accessPath = filePath;
        }

        public DataAccess(string filepath)
        {

            AcessPath = filepath;

        }

        public TracksCollection GetAllTracks()
        {
            throw new NotImplementedException();
        }

        public TracksCollection GetTrackPath()
        {
            throw new NotImplementedException();
        }
    }
}
