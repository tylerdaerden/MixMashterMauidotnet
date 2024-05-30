using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MixMashter.Model.Tracks;
using MixMashter.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.ViewModel
{
    public partial class TracksPageViewModel : BaseViewModel
    {

        #region Constructeurs

        public TracksPageViewModel(IDataAccess dataAccessService, IAlertService alertService) : base(alertService)
        {
            dataAcess = dataAccessService;
            Trackslist = dataAccessService.GetAllTracks(); // get all tracks  from chosen DataAccessSource
        } 

        #endregion

        #region Props
        /// <summary>
        /// manager to the data access (Csv, Json , XAML , SQL) etc... 
        /// </summary>
        private IDataAccess dataAcess;

        /// <summary>
        /// Collection of all tracks
        /// </summary>
        public TracksCollection Trackslist { get; set; }


        /// <summary>
        /// Tracks selected in the listview 
        /// </summary>
        [ObservableProperty]
        private Tracks tracksUserSelection;





        [RelayCommand()]
        private async void ShowTracksDetails()
        {
            if (TracksUserSelection != null)
            {
                await alertService.ShowAlert("Selection", $"Votre Choix :\n{TracksUserSelection.Name}\n" +
                    $"{TracksUserSelection.ArtistName}\n{TracksUserSelection.Length}sec\nlien de lecture YTB : {TracksUserSelection.Urlpath} ");
            }
            else
            {
                await alertService.ShowAlert("Erreur", "Aucune Piste n'a été choisie");
            }
        }

        [RelayCommand()]
        private async void TestBindingShowProperties()
        {
            await alertService.ShowAlert("Informations de l'application ", $"En interne, les valeur des propriétés sont : " +
            $"\n{MainInfos.Name}\n{MainInfos.WebSite}\n");
        }
        [RelayCommand()]
        private async void TestBindingChangeProperties()
        {
            MainInfos.Name = "MixMashterPREMIUM";
            MainInfos.WebSite = "http://MixMashterPremium.com";
        }


        #endregion

    }
}
