using MixMashter.Model.Tracks;
using MixMashter.Utilities.DataAccess;
using MixMashter.Utilities.DataAccess.Files;
using MixMashter.Utilities.Interfaces;
using MixMashter.ViewModel;

namespace MixMashter.View;

public partial class TracksPage : ContentPage
{
	public TracksPage(TracksPageViewModel tracksPageVM, IDataAccess dataAcessService, IAlertService alertService)
	{
        dataAccess = dataAcessService;
        alert = alertService;
        tracksPageViewModel = tracksPageVM;
        // Definition du BindingContext avec le ViewModel
        BindingContext = tracksPageVM;
		InitializeComponent();
	}

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
    private TracksPageViewModel tracksPageViewModel;



    #endregion

    private void Button_DescendantAdded(object sender, ElementEventArgs e)
    {

    }

    //Old Button Text (NON WORKING) SQL ACCESS DATAS
    //private void buttonaccessSQL_Clicked(object sender, EventArgs e)
    //{
    //    alert.ShowAlert("ok", "ça réagit");

    //    string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MixMashter\MixMashter\Configuration\Datas\Config.txt";
    //    DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
    //    DataAccessSql daSql = new DataAccessSql(dataFilesManager, alert);
    //    TracksCollection tracks = daSql.GetAllTracks();
    //    tracks.ToList().ForEach(track => lblDebug.Text += $"\n Artist Name:  {track.ArtistName} , Track Name {track.Name} ");
    //}


}