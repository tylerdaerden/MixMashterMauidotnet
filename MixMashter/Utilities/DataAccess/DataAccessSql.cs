using CommunityToolkit.Maui.Core.Views;
using Microsoft.Data.SqlClient;
using MixMashter.Model.Artists;
using MixMashter.Model.Tracks;
using MixMashter.Utilities.DataAccess.Files;
using MixMashter.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Utilities.DataAccess
{
    public class DataAccessSql : DataAccess, IDataAccess
    {
        public DataAccessSql(DataFilesManager dfm, IAlertService alertService) : base(dfm, alertService)
        {
            try
            {
                AccessPath = DataFilesManager.DataFiles.GetValueByCodeFunction("CONNECTION_STRING");
                SqlConnection = new SqlConnection(AccessPath);
                SqlConnection.Open();
                

            }

            catch (Exception ex)
            {
                alertService.ShowAlert("Erreur De Connection", "Votre Connexion à la DB a échoué.");
            }



        }

        /// <summary>
        /// Connexion à notre DB via Sql Connection du package Data.SqlCLient 
        /// </summary>
        public SqlConnection SqlConnection { get; set; }

        public override ArtistsCollection GetAllArtists()
        {
            try
            {
                ArtistsCollection artists = new ArtistsCollection();
                string sqlcommand = "SELECT * FROM Artists";
                SqlCommand cmd = new SqlCommand(sqlcommand , SqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                   
                }
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", ex.Message);
                return null;
            }


        }


        public static Artist GetArtist(SqlDataReader dr)
        {
            string type = dr.GetValue(1).ToString();

            switch (type) 
            {
                case "Artist":
                    return new Artist(
                        id : dr.GetInt32(0),
                        artistname : dr.GetString(2),
                        lastname : dr.GetString(3),
                        firstname : dr.GetString(4),
                        gender : dr.GetBoolean(5)
                        );
                case "Masher":
                    return new Masher(
                        id: dr.GetInt32(0),
                        artistname: dr.GetString(2),
                        lastname: dr.GetString(3),
                        firstname: dr.GetString(4),
                        gender: dr.GetBoolean(5),
                        mashername: dr.GetString(6)

                        );

                default:
                    return null;




            } 


        }



        /// <summary>
        /// get all tracks from a sql DB based on type Tracks or Masher
        /// </summary>
        /// <returns></returns>
        public override TracksCollection GetAllTracks()
        {
            try
            {
                TracksCollection tracks = new TracksCollection();
                string sqlcommand = "SELECT * FROM Tracks";
                SqlCommand cmd = new SqlCommand(sqlcommand, SqlConnection);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Tracks tr = GetTracks(dataReader);
                    if (tr != null)
                    {
                        tracks.Add(tr);
                    }
                }
                dataReader.Close();
                return tracks;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", ex.Message);
                return null;
            }

        }

        /// <summary>
        /// Reads data from SqlDataReader and creates a Tracks object.
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static Tracks GetTracks(SqlDataReader dr)
        {

            string type = dr.GetValue(1).ToString();

            //usage du switch pour implémentation later du mashup ! 
            switch (type)
            {

                case "Tracks":
                    return new Tracks(
                        id: dr.GetInt32(0),
                        name: dr.GetString(2),
                        length: dr.GetInt32(3),
                        artistName: dr.GetString(4),
                        urlpath: dr.GetString(5),
                        explicitlyrics: dr.GetBoolean(6),
                        pictureName: dr.GetString(7)
                        );

                case "Mashups":
                    return new Mashup(
                        id: dr.GetInt32(0),
                        name: dr.GetString(2),
                        length: dr.GetInt32(3),
                        artistname: dr.GetString(4),
                        urlpath: dr.GetString(5),
                        explicitlyrics: dr.GetBoolean(6),
                        pictureName: dr.GetString(7),
                        originalartists: dr.GetString(8),
                        masher: dr.GetString(9)
                        ); ;

                default:
                    return null;
            }
        }

        // A FAIRE LATER 

        /// <summary>
        /// Update a all tracks on Sql DB 
        /// </summary>
        /// <param name="tracks"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool UpdateAllTracks(TracksCollection tracks)
        {
            throw new NotImplementedException();
        }


        public override TracksCollection GetTrackPath()
        {
            throw new NotImplementedException();
        }

        public override bool UpdateAllArtists(ArtistsCollection artists)
        {
            throw new NotImplementedException();
        }
    }
}
