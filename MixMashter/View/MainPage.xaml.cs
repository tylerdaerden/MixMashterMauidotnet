using MixMashter.Model.User;
using MixMashter.Model;
using MixMashter.Model.Artists;
using MixMashter.Utilities.DataAccess.Files;
using MixMashter.Utilities.DataAccess;
using MixMashter.Model.Tracks;

namespace MixMashter
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }


        private void buttonCreateUser_Clicked(object sender, EventArgs e)
        {
            User JohnDoe = new User(id: 1, "John", "Doe", "Johndoe",1 , "johndoe@gmail.com", new DateTime(2000, 4, 15), "Test123456789");

            lblDebug.Text = "User Crée";

        }

        private void buttonCreateAdmin_Clicked(object sender, EventArgs e)
        {

            Admin Boss = new Admin(1 ,"Le" , "Boss" , "Leboss" , 2 , "leboss@gmail.com" , new DateTime(1987,11,25) , "Test123456789" , true);

            lblDebug.Text = "Admin Crée";

        }

        private void buttonAccessCsv_Clicked(object sender, EventArgs e)
        {
            // CONFIG_FILE POUR TOUR ↓↓↓
            string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MixMashter\MixMashter\Configuration\Datas\Config.txt";
            // CONFIG_FILE POUR PORTABLE ↓↓↓
            //string CONFIG_FILE = @"";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFiles daCsv = new DataAccessCsvFiles(dataFilesManager);
            TracksCollection trackscollection = daCsv.GetAllTracks();
            trackscollection.ToList().ForEach(tc => lblDebug.Text += $"\n TrackName : {tc.Name} , Artist : {tc.ArtistName} , Length : {tc.Length.ToString()}");

        }

        private void buttonAccessJson_Clicked(object sender, EventArgs e)
        {
            // CONFIG_FILE POUR TOUR ↓↓↓
            string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MixMashter\MixMashter\Configuration\Datas\Config.txt";
            // CONFIG_FILE POUR PORTABLE ↓↓↓
            //string CONFIG_FILE = @"";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessJsonFiles da = new DataAccessJsonFiles(dataFilesManager);
            TracksCollection tracks = da.GetAllTracks();
            tracks.ToList().ForEach(tr => lblDebug.Text += $"\n Track: {tr.Name} - Artist {tr.ArtistName} - Url: {tr.Urlpath}");

        }
    }

}
