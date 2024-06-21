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

}