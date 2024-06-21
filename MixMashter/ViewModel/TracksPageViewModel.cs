using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MixMashter.Model.Tracks;
using MixMashter.Utilities.Interfaces;
using MixMashter.Utilities.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
                //await alertService.ShowAlert("Selection", $"Votre Choix :\n{TracksUserSelection.Name}\n" +
                //    $"{TracksUserSelection.ArtistName}\n{TracksUserSelection.Length}sec\nlien de lecture YTB : {TracksUserSelection.Urlpath} ");
                //version sans le lien YTB (moins charger l'info)
                await alertService.ShowAlert("Selection", $"Votre Choix :\n{TracksUserSelection.Name}\n" + 
                    $"{TracksUserSelection.ArtistName}\n{TracksUserSelection.Length}sec");
            }
            else
            {
                await alertService.ShowAlert("Erreur", "Aucune Piste n'a été choisie");
            }
        }
        /// <summary>
        /// Procedure d'ouverture du lien (url path) de la piste YTB ici 
        /// </summary>
        /// <param name="url"></param>
        [RelayCommand()]
        private async void OpenUrlTrack(string url)
        {


            if (TracksUserSelection != null)
            {
                url = TracksUserSelection.Urlpath;
                OpenBrowser(url);
            }
            else
            {
                await alertService.ShowAlert("Erreur", "Aucune Piste n'a été choisie");
            }
        }

        /// <summary>
        /// procedure d'ouverture d'URL avec verifications , lien de la requête avec update : https://github.com/dotnet/runtime/issues/17938
        /// la procedure va d'abor analyser notre OS , puis exécuter la cmd terminal adequate d'ouverture d'URL , que ce soit en Windows , Linux , IOS
        /// </summary>
        /// <param name="url"></param>
        public static void OpenBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                //ici l'ajout de CreateNoWindow = true ne montre pas l'ouverture de la fenêtre cmd en windows(plus esthétique) 
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                throw new NotImplementedException();
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
