using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MixMashter.Model.Artists;
using MixMashter.Utilities.Interfaces;
using MixMashter.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.ViewModel
{
    public partial class ArtistsPageViewModel : BaseViewModel
    {
        public ArtistsPageViewModel(IDataAccess dataAccessService, IAlertService alertService) : base(alertService)
        {
            dataAccess = dataAccessService;
            Artists = dataAccess.GetAllArtists();   //get user's collection datas from chosen DataAccessSource (excel, csv, json...).

        }

        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;
        /// <summary>
        /// collection of all Artist
        /// </summary>
        public ArtistsCollection Artists { get; set; }

        /// <summary>
        /// Artist selected in the listview
        /// </summary>
        [ObservableProperty]
        private Artist artistSelection;

        /// <summary>
        /// Artist who will be displayed in the popup screen
        /// </summary>
        [ObservableProperty]
        private Artist artistPopupDisplayed;

        /// <summary>
        /// flag to know if user want to add a new Artist or consulting an existing one.
        /// </summary>
        [ObservableProperty]
        private bool isNewArtistAction;

        /// <summary>
        /// Save changes, add, delete Artists datas to the source.
        /// </summary>
        [RelayCommand()]
        public void SaveDatas()
        {
            if (dataAccess.UpdateAllArtists(Artists))
            {
                alertService.ShowAlert("Sauvegarde", "Les données des Artistes ont bien été sauvegardées");
            }
            else
            {
                alertService.ShowAlert("Sauvegarde erreur", "Une erreur est survenue lors de la sauvegarde");
            };
        }

        /// <summary>
        /// Show popup for a new Artist edition
        /// command binded to the "Add new Artist" in the Page, will open the popup screen
        /// </summary>
        [RelayCommand()]
        public void ShowNewArtistPopup()
        {
            //store information to know we will display the "Add New Artist" button on the popup display
            IsNewArtistAction = true;
            //get an id for the new Artist
            int nextId = Artists.GetNextId();
            //create a blank Artist
            ArtistPopupDisplayed = new Artist(nextId, "Nom de L'artiste", "Nom", "Prenom", false , "image.fichier");
            //create an instance of the NewArtistPopup and give this viewModel
            var popup = new NewArtistPopup(this);
            //show the popup on screen
            Shell.Current.CurrentPage.ShowPopup(popup);
        }

        /// <summary>
        /// Command binded to the "Add new Member" button in the pop up display
        /// </summary>
        [RelayCommand()]
        public void AddNewArtist()
        {
            if (Artists.AddArtist(ArtistPopupDisplayed))
            {
                alertService.ShowAlert("Ajout", "Le nouvel Artist a bien été ajouté");
            }
            else
            {
                alertService.ShowAlert("Ajout erreur", "Une erreur est survenue lors de l'ajout");
            };
            //reset the property for a future choice.
            IsNewArtistAction = false;
        }

        /// <summary>
        /// Command Binded to the "Remove Artist" button to the selected 
        /// </summary>
        [RelayCommand()]

        public async void RemoveArtist()
        {
            if (ArtistSelection != null)
            {

                if (await alertService.ShowConfirmation($"Cette opération supprimera {ArtistSelection.ArtistName} ", "Êtes vous sûr ?"))
                {
                    string artistname = ArtistSelection.ArtistName;
                    if (Artists.RemoveArtist(ArtistSelection))
                    {
                        //await pas nécessaire car pas d'appel ou de code après 
                        alertService.ShowAlert("Suppression effectuée", $"{artistname} a bien été supprimé.e");
                    }
                    else
                    {
                        //await pas nécessaire car pas d'appel ou de code après 
                        alertService.ShowAlert("Erreur de Suppression", $"Une erreur est survenue lors de la supression de {artistname} ");
                    }
                }
            }

            else
            {
                alertService.ShowAlert("Erreur", "Pas de Selection d'artiste");
            }

        }

        /// <summary>
        /// Get selection event from the listView
        /// Show popup for an existing artist read and edition
        /// </summary>
        [RelayCommand()]
        private void SelectArtist(Artist art)
        {
            //prevent to display "Add New Artist button" on the popup display because it's an existing one
            IsNewArtistAction = false;
            //affect the ArtistPopupDisplayed property to this current artist selected.
            ArtistPopupDisplayed = art;
            //create an instance of the NewArtistPopup and give this viewModel
            var popup = new NewArtistPopup(this);
            //show the popup on screen
            Shell.Current.CurrentPage.ShowPopup(popup);
        }


    }//end class

}
