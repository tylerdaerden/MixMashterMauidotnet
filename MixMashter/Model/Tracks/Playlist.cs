using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MixMashter.Model.Tracks
{
    public class Playlist : ObservableCollection<Mashup>
    {


        #region Constructeurs

        public Playlist() { }

        #endregion


        #region Methodes

        public void AddMashup(Mashup msp)
        {
            if (this.Count == 0  )
            {
                this.Add(msp);
            }
        }


        public int PlaylistLength(Mashup msp)
        {
            return 1;
        }


        #endregion


    }
}
