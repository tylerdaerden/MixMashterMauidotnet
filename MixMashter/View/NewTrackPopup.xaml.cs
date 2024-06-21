using CommunityToolkit.Maui.Views;
using MixMashter.ViewModel;

namespace MixMashter.View;

public partial class NewTrackPopup : Popup
{
	public NewTrackPopup(TracksPageViewModel tracksPageVM)
	{
		InitializeComponent();
	}

    private void buttonClose_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }

}