using MixMashter.Model.Artists;
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
        public DataAccessJsonFiles(DataFilesManager dfm , IAlertService alertService) : base(dfm)
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
        /// <summary>
        /// Get All Artists in an ArtistCollection 
        /// </summary>
        /// <returns></returns>
        public override ArtistsCollection GetAllArtists()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("ARTISTS");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                ArtistsCollection? art = new ArtistsCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                art = JsonConvert.DeserializeObject<ArtistsCollection>(jsonFile, settings);
                return art;
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

        /// <summary>
        /// Update Json source file from the Artist collection
        /// </summary>
        /// <param name="artists"></param>
        /// <returns></returns>
        public override bool UpdateAllArtists(ArtistsCollection artists)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("ARTISTS");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(artists, Formatting.Indented, settings);
                File.WriteAllText(AccessPath, json);
                return true;
            }
            else
            {
                //Console.WriteLine("UpdateAllArtistsDatas error can't update datasource file");
                return false;
            }
        }
    }
}
