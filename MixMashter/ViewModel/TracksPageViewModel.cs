using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MixMashter.Model.Tracks;
using MixMashter.Utilities.Interfaces;
using MixMashter.Utilities.Services;
using MixMashter.View;
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

        /// <summary>
        /// Tracks who will be displayed in the popup screen
        /// </summary>
        [ObservableProperty]
        private Tracks trackPopupDisplayed;

        /// <summary>
        /// flag to know if user want to add a new Tracks or consulting an existing one.
        /// </summary>
        [ObservableProperty]
        private bool isNewTrackAction;


        /// <summary>
        /// Show popup for a new Track edition
        /// command binded to the "Add new Track" in the Page, will open the popup screen
        /// </summary>
        [RelayCommand()]
        public void ShowNewTrackPopup()
        {
            //store information to know we will display the "Add New Track" button on the popup display
            IsNewTrackAction = true;
            //get an id for the new Artist
            int nextId = Trackslist.GetNextId();
            //create a blank Artist
            TrackPopupDisplayed = new Tracks(nextId, "Nom de La Piste", 999, "Nom de l'Artiste Interprete", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", false, "image.png");
            //create an instance of the NewArtistPopup and give this viewModel
            var popup = new NewTrackPopup(this);
            //show the popup on screen
            Shell.Current.CurrentPage.ShowPopup(popup);
        }


        /// <summary>
        /// Command binded to the "Add new Track" button in the pop up display
        /// </summary>
        [RelayCommand()]
        public void AddNewTrack()
        {
            if (Trackslist.AddTrack(TrackPopupDisplayed))
            {
                alertService.ShowAlert("Ajout", "La nouvelle piste a bien été ajouté");
            }
            else
            {
                alertService.ShowAlert("Ajout erreur", "Une erreur est survenue lors de l'ajout");
            };
            //reset the property for a future choice.
            IsNewTrackAction = false;
        }

        /// <summary>
        /// Command Binded to the "Remove Tracks" button to the selected 
        /// </summary>
        [RelayCommand()]

        public async void RemoveTracks()
        {
            if (TracksUserSelection != null)
            {

                if (await alertService.ShowConfirmation($"Cette opération supprimera {TracksUserSelection.Name} ", "Êtes vous sûr ?"))
                {
                    string trackname = TracksUserSelection.Name;
                    if (Trackslist.RemoveTrack(TracksUserSelection))
                    {
                        //await pas nécessaire car pas d'appel ou de code après 
                        alertService.ShowAlert("Suppression effectuée", $"{trackname} a bien été supprimé.e");
                    }
                    else
                    {
                        //await pas nécessaire car pas d'appel ou de code après 
                        alertService.ShowAlert("Erreur de Suppression", $"Une erreur est survenue lors de la supression de {trackname} ");
                    }
                }
            }

            else
            {
                alertService.ShowAlert("Erreur", "Pas de Selection de piste");
            }

        }

        /// <summary>
        /// Get selection event from the listView
        /// Show popup for an existing artist read and edition
        /// </summary>
        [RelayCommand()]
        private void SelectTrack(Tracks trk)
        {
            //prevent to display "Add New Artist button" on the popup display because it's an existing one
            IsNewTrackAction = false;
            //affect the ArtistPopupDisplayed property to this current artist selected.
            TrackPopupDisplayed = trk;
            //create an instance of the NewArtistPopup and give this viewModel
            var popup = new NewTrackPopup(this);
            //show the popup on screen
            Shell.Current.CurrentPage.ShowPopup(popup);
        }



        /// <summary>
        /// Save changes, add, delete Artists datas to the source.
        /// </summary>
        [RelayCommand]
        public void SaveDatas()
        {

            if (dataAcess.UpdateAllTracks(Trackslist))
            {
                alertService.ShowAlert("Sauvegarde Effectuée!", "Les Données Tracks ont bien été sauvegardées dans notre DB");

            }
            else
            {
                alertService.ShowAlert("Sauvegarde Non-Effectuée!", "Une erreur est survenue lors de la sauvegarde");

            }

        }


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
