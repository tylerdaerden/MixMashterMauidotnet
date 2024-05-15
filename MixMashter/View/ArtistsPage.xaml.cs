using MixMashter.ViewModel;

namespace MixMashter.View;

public partial class ArtistsPage : ContentPage
{
	public ArtistsPage(ArtistsPageViewModel artistPageVM)
	{
		BindingContext = artistPageVM;
		InitializeComponent();
	}
}