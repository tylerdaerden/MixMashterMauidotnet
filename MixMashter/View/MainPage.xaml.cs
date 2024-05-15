using MixMashter.Model.User;
using MixMashter.Model;
using MixMashter.Model.Artists;
using MixMashter.Utilities.DataAccess.Files;
using MixMashter.Utilities.DataAccess;
using MixMashter.Model.Tracks;
using MixMashter.Utilities.Services;
using MixMashter.ViewModel;
using MixMashter.Utilities.Interfaces;

namespace MixMashter
{
    public partial class MainPage : ContentPage
    {


        #region Constructeurs


        public MainPage(MainPageViewModel mainPageVM , IDataAccess dataAcessService, IAlertService alertService)
        {
            dataAccess = dataAcessService;
            alert = alertService;
            mainPageViewModel = mainPageVM;
            // Definition du BindingContext avec le ViewModel
            BindingContext = mainPageVM;
            InitializeComponent();

        }


        #endregion


        #region Props

        /// <summary>
        /// Manager to the data access (CSV , JSON , SQL ) 
        /// </summary>
        private IDataAccess dataAccess;

        /// <summary>
        /// Manager to the data access (CSV , JSON , SQL ) 
        /// </summary>
        private IAlertService alert;

        /// <summary>
        /// keep a reference to the ViewModel for eventual testings
        /// </summary>
        private MainPageViewModel mainPageViewModel;



        #endregion

        #region Old Depreciated code pour Exo (pas la bonne pratique , pas de code ici logiquement)

        //private void buttonCreateUser_Clicked(object sender, EventArgs e)
        //{
        //    User JohnDoe = new User(id: 1, "John", "Doe", "Johndoe",1 , "johndoe@gmail.com", new DateTime(2000, 4, 15), "Test123456789");

        //    lblDebug.Text = "User Crée";

        //}

        //private void buttonCreateAdmin_Clicked(object sender, EventArgs e)
        //{

        //    Admin Boss = new Admin(1 ,"Le" , "Boss" , "Leboss" , 2 , "leboss@gmail.com" , new DateTime(1987,11,25) , "Test123456789" , true);

        //    lblDebug.Text = "Admin Crée";

        //} 



        //private void buttonAccessCsv_Clicked(object sender, EventArgs e)
        //{
        //    // CONFIG_FILE POUR TOUR ↓↓↓
        //    //string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MixMashter\MixMashter\Configuration\Datas\Config.txt";
        //    // CONFIG_FILE POUR PORTABLE ↓↓↓
        //    string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MixMashter\MixMashter\Configuration\Datas\Config.txt";
        //    DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
        //    DataAccessCsvFiles daCsv = new DataAccessCsvFiles(dataFilesManager);
        //    TracksCollection trackscollection = daCsv.GetAllTracks();
        //    trackscollection.ToList().ForEach(tc => lblDebug.Text += $" TrackName : {tc.Name} , Artist : {tc.ArtistName} , Length : {tc.Length.ToString()}\n");

        //}

        //private void buttonAccessJson_Clicked(object sender, EventArgs e)
        //{
        //    // CONFIG_FILE POUR TOUR ↓↓↓
        //    //string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MixMashter\MixMashter\Configuration\Datas\Config.txt";
        //    // CONFIG_FILE POUR PORTABLE ↓↓↓
        //    string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MixMashter\MixMashter\Configuration\Datas\Config.txt";
        //    DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
        //    DataAccessJsonFiles da = new DataAccessJsonFiles(dataFilesManager);
        //    TracksCollection tracks = da.GetAllTracks();
        //    tracks.ToList().ForEach(tr => lblDebug.Text += $" Track: {tr.Name} - Artist {tr.ArtistName} - Url: {tr.Urlpath}\n");

        //}

        //private async void buttonTestDisplay_Clicked(object sender, EventArgs e)
        //{
        //    AlertServiceDisplay alertService = new AlertServiceDisplay();

        //    await alertService.ShowAlert("Titre de mon pop up" , "voici un exemple d'alerte");
        //    if (await alertService.ShowConfirmation("Questionnaire" , "Etes-vous d'accord de répondre à une question?", "Yep vas y " , "Nope DEGAGE !!!"))
        //    {
        //        var userEntry = await alertService.ShowPrompt("Saisie du nom", "Votre prénom ? ");
        //        var userChoice = await alertService.ShowQuestion("Votre elderscoll préféré ?", "Skyrim", "TESO", "Gneeeeuh j'préféreu Col of deuty gneuuh");
        //        await alertService.ShowAlert("Choix elderscroll", $" Merci {userEntry} , voici votre choix : {userChoice}");
        //    }


        //}



        #endregion





    }//end content page

}
