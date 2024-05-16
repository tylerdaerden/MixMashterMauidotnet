using CommunityToolkit.Maui.Views;
using MixMashter.ViewModel;

namespace MixMashter.View;

public partial class NewArtistPopup : Popup
{
	public NewArtistPopup(ArtistsPageViewModel artistsPageVM)
	{
		BindingContext = artistsPageVM;
		InitializeComponent();
	}

    private void buttonClose_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }





}