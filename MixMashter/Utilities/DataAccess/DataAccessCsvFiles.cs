using MixMashter.Model.Tracks;
using MixMashter.Utilities.Interfaces;
using MixMashter.Utilities.DataAccess.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMashter.Model.Artists;

namespace MixMashter.Utilities.DataAccess
{
    public class DataAccessCsvFiles : DataAccess, IDataAccess
    {
        #region Constructeurs
        public DataAccessCsvFiles(string filePath) : base(filePath)
        {
        }
        /// <summary>
        /// Constructor associated with a datafileManager, it contains path to a config text file
        /// wich contains path to csv files
        /// </summary>
        /// <param name="dfm"></param>
        public DataAccessCsvFiles(DataFilesManager dfm) : base(dfm) { } 
        #endregion


        public override TracksCollection GetAllTracks()
        {
            List<string> listToRead = new List<string>();
            TracksCollection tracks = new TracksCollection();
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("TRACKS");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Tracks tr = GetTracks(s);
                    if (tr != null)
                    {
                        tracks.AddTrack(tr);
                    }
                }
                return tracks;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Split a line like : Customer;1;Beumier;Damien;true;beumierdamien@gmail.com;485678234;New;;;;
        /// and create instance with each fields.
        /// </summary>
        /// <param name="csvline"></param>
        /// <returns></returns>
        private static Tracks GetTracks(string csvline)
        {
            string[] fields = csvline.Split(';');
            if (!string.IsNullOrEmpty(fields[0]) && fields[0].Equals("TRACKS")) 
            {
                Tracks t = new Tracks(id: int.Parse(fields[1]), name: fields[2], length: int.Parse(fields[3]), artistName: fields[4], urlpath: fields[5], explicitlyrics: bool.Parse(fields[6]) ,pictureName: fields[7] );

                return t;
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
        /// Convert "0" or "1" from csv File to bool type false or true
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        static private bool CvrtstrToBool(string field)
        {
            return Convert.ToBoolean(int.Parse(field));
        }

        public override ArtistsCollection GetAllArtists()
        {
            throw new NotImplementedException();
        }

        public override bool UpdateAllArtists(ArtistsCollection artists)
        {
            throw new NotImplementedException();
        }



    }
}
