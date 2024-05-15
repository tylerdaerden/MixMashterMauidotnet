using MixMashter.Utilities.ToolBox.Checks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.Website
{
    public class MainInformations : INotifyPropertyChanged
    {

        //implémentation de  INotifyPropertyChanged ↓↓↓
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Attributs

        private string _name = "";
        private string _webSite = "";

        #endregion

        #region Constructeur

        public MainInformations(string name, string website)
        {
            Name = name;
            WebSite = website;

        }

        #endregion

        #region Props

        public string Name 
        { 
            get => _name;
            set
            {
                if(CheckTools.CheckNameMin1Char(value))
                {
                    _name = value;
                }
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// url App"s website
        /// </summary>
        public string WebSite
        {
            get => _webSite;
            set
            {
                if (CheckTools.CheckUrl(value))
                {
                    _webSite = value;
                }
                OnPropertyChanged(nameof(WebSite));

            }
        }

        #endregion


        #region Methodes
        //méthode ajoutée pour déclencher l’événement et notifier la cible du changement de propriété source. INOTIFYPROPERTYCHANGED
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion








    }
}
