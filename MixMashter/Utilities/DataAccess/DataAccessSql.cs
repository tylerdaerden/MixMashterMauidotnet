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
                SqlCommand cmd = new SqlCommand(sqlcommand, SqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artist art = GetArtist(reader);
                    if (art != null)
                    {
                        artists.Add(art);
                    }
                }
                reader.Close();
                return artists;
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
                        id: dr.GetInt32(0),
                        artistname: dr.GetString(2),
                        lastname: dr.GetString(3),
                        firstname: dr.GetString(4),
                        gender: dr.GetBoolean(5),
                        picturename: dr.GetString(6)
                        );
                case "Masher":
                    return new Masher(
                        id: dr.GetInt32(0),
                        artistname: dr.GetString(2),
                        lastname: dr.GetString(3),
                        firstname: dr.GetString(4),
                        gender: dr.GetBoolean(5),
                        picturename: dr.GetString(6),
                        mashername: dr.GetString(7)
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

        private string GetSqlInsertArtist(Artist art)
        {
            //get the type of the Artist
            string[] strType = art.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];

            switch (type)
            {
                case "Artist":
                    return $"INSERT INTO Artists (Type, ArtistName, LastName, FirstName, Gender, PictureName) VALUES('{type}','{art.ArtistName}','{art.LastName}','{art.FirstName}','{BoolSqlConvert(art.Gender)}','{art.PictureName}');SELECT SCOPE_IDENTITY();";
                case "Masher":
                    Masher mash = (Masher)art;
                    return $"INSERT INTO Artists (Type, ArtistName, LastName, FirstName, Gender, PictureName,MasherName) VALUES('{type}','{art.ArtistName}','{art.LastName}','{art.FirstName}','{BoolSqlConvert(art.Gender)}','{art.PictureName}','{mash.MasherName}');SELECT SCOPE_IDENTITY();";

                default:

                    return null;
            }

        }

        /// <summary>
        /// creation d'une requete sql pour MAJ d'un artiste (informations) sur base du type et de l'id 
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        private string GetSqlUpdateAllArtist(Artist art)
        {
            //get the type of the Artist
            string[] strType = art.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];

            switch (type)
            {

                case "Artist":
                    //Creation d'une query pour Update sur la Table Artist
                    return $"UPDATE Artists SET " +
                            $"ArtistName = '{art.ArtistName}', " +
                            $"LastName ='{art.LastName}', " +
                            $"FirstName = '{art.FirstName}', " +
                            $"Gender = {BoolSqlConvert(art.Gender)}, " +
                            $"PictureName = '{art.PictureName}' " +
                            $"WHERE Id = {art.Id};";

                case "Masher":
                    //cast de Artist en MAsher
                    Masher mash = (Masher)art;
                    //Query pour Masher Pas encore de masher dans le projet
                    return $"UPDATE Artists SET " +
                            $"ArtistName = '{art.ArtistName}', " +
                            $"LastName ='{art.LastName}', " +
                            $"FirstName = '{art.FirstName}', " +
                            $"Gender = {BoolSqlConvert(art.Gender)}, " +
                            $"PictureName = '{art.PictureName}', " +
                            $"MasherName = '{mash.MasherName}' " +
                            $"WHERE Id = {art.Id};";

                default:
                    //si pas reconnu , retournera null.
                    return null;

            }

        }


        /// <summary>
        /// Update Artists database table from the working ArtistCollection 
        /// </summary>
        /// <param name="artists"></param>
        /// <returns></returns>
        public override bool UpdateAllArtists(ArtistsCollection artists)
        {
            string sql = string.Empty;

            try
            {
                //récupérer tous les ID's depuis notre Serveur SQL
                List<int> sqlIds = new List<int>();
                string sqlQuery = $"Select Id FROM Artists";
                SqlCommand selectCommand = new SqlCommand(sqlQuery, SqlConnection);
                //rename de la variable
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    sqlIds.Add(reader.GetInt32(0));
                }
                reader.Close();
                //Comparer les Id's avec ceux dans notre programme
                List<int> programIds = new List<int>();
                foreach (Artist art in artists)
                {
                    programIds.Add(art.Id);
                }
                //Trouver les IDs manquants
                List<int> missingIdsList = sqlIds.Except(programIds).ToList();

                //Supprimer les Ids manquants du programme
                foreach (int missingId in missingIdsList)
                {
                    //Supprimer ID manquant de notre DB
                    string deleteSql = $"DELETE FROM ARTISTS WHERE Id = {missingId} ";
                    SqlCommand deleteCommand = new SqlCommand(deleteSql, SqlConnection);
                    deleteCommand.ExecuteNonQuery();
                }

                foreach (Artist art in artists)
                {

                    //Si déjà dans la db, update, sinon Insert 
                    sql = IsInDb(art.Id, "Id", "Artists") ? GetSqlUpdateAllArtist(art) : GetSqlInsertArtist(art);
                    if (!string.IsNullOrEmpty(sql))
                    {
                        SqlCommand command = new SqlCommand(sql, SqlConnection);
                        //get id autocreated by the database (when update insertedId = 0)
                        int insertedId = Convert.ToInt32(command.ExecuteScalar());
                        if (insertedId > 0)
                        {
                            art.Id = insertedId;
                        }
                    }
                    else
                    {
                        alertService.ShowAlert("erreur sur la recuperation d'ID", "Id non recupere");
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", $"{ex.Message} \nSQL Query: {sql}");
                return false;
            }
        }


        #region Old Update Artist (sans le delete)
        //try
        //{
        //    foreach (Artist art in artists)
        //    {
        //        //vérification de présence ou non dans DB sur base de l'Id , si déja présent update sinon insert nouvelle entrée
        //        sql = IsInDb(art.Id, "Id", "Artists") ? GetSqlUpdateAllArtist(art) : GetSqlInsertArtist(art);

        //        if (!string.IsNullOrEmpty(sql))
        //        {
        //            //Execution de la commande après vérif de non null 
        //            SqlCommand command = new SqlCommand(sql, SqlConnection);
        //            // récupération de l'Id auto incrémenté de la DB 
        //            int insertedId = Convert.ToInt32(command.ExecuteScalar());

        //            if (insertedId > 0)
        //            {
        //                // MAJ de l'Id de Artist
        //                art.Id = insertedId;
        //            }
        //        }
        //    }
        //    return true; //MAJ succès ! 
        //}
        //catch (Exception ex)
        //{
        //    //Gestion exception avec alerte
        //    alertService.ShowAlert("Erreur lors de la requête dans notre Base de Données", $"{ex.Message} \n Requete SQL : {sql}");
        //    return false;//echec MAJ !
        //} 
        #endregion


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


        /// <summary>
        /// Checks if a given ID exists in the specified table of the database.
        /// </summary>
        /// <param name="idValue">ID value to check</param>
        /// <param name="idColumnName">Name of the ID column</param>
        /// <param name="tableName">Name of the table</param>
        /// <returns>True if the ID is found in the database, otherwise false</returns>
        private bool IsInDb(int idValue, string idColumnName, string tableName)
        {
            string sql = $"SELECT * FROM {tableName} WHERE {idColumnName} = {idValue}";

            // Execute the SQL command.
            SqlCommand cmd = new SqlCommand(sql, SqlConnection);
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Check if any rows are returned.
            bool inDb = dataReader.HasRows;

            // Close the data reader.
            dataReader.Close();

            return inDb;
        }

        /// <summary>
        /// Method who return url trackpath as a link to play the track 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override TracksCollection GetTrackPath()
        {
            throw new NotImplementedException();
        }

        private string BoolSqlConvert(bool b)
        {
            return b ? "1" : "0";
        }

    }
}
