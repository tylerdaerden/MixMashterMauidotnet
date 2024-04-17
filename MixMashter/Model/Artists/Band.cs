using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Model.Artists
{
    public class Band : ObservableCollection<Artist>
    {

        // CLASSE DEPRECIEE A VOIR SI REINSEREE PLUS TARD !!!


        #region Attributs

        private string _bandName;
        private bool _isActive;
        private int _yearFonded;

        #endregion


        #region Constructeur

        public Band() { }


        #endregion


        #region Props


        public string Bandname
        {
            get { return _bandName; }
            set { _bandName = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public int YearFonded
        {
            get { return _yearFonded; }
            set { _yearFonded = value; }
        }

        #endregion


        #region Methodes



        #endregion





    }
}
