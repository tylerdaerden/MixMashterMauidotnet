using MixMashter.Model.Tracks;
using MixMashter.Utilities.DataAccess.Files;
using MixMashter.Utilities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Utilities.DataAccess
{
    public class DataAccessJsonFiles : DataAccess, IDataAccess
    {

        public DataAccessJsonFiles(string filePath) : base(filePath)
        {
        }
        public DataAccessJsonFiles(string filePath, string[] extensions) : base(filePath, extensions)
        {

        }
        public DataAccessJsonFiles(DataFilesManager dfm) : base(dfm)
        {

        }

        /// <summary>
        /// Get All Tracks in a TrackCollection from a JsonFile code TRACKS
        /// </summary>
        /// <returns></returns>

        public override TracksCollection GetAllTracks()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("TRACKS");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                TracksCollection? tr = new TracksCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                tr = JsonConvert.DeserializeObject<TracksCollection>(jsonFile, settings);
                return tr;
            }
            else
            {
                return null;
            }

        }



        public override TracksCollection GetTrackPath()
        {
            throw new NotImplementedException();
        }
    }
}
