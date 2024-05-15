using MixMashter.ViewModel;

namespace MixMashter.View;

public partial class TracksPage : ContentPage
{
	public TracksPage(TracksPageViewModel tracksPageVM)
	{
		BindingContext = tracksPageVM;
		InitializeComponent();
	}
}