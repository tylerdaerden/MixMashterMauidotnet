using CommunityToolkit.Mvvm.ComponentModel;
using MixMashter.Model.Website;
using MixMashter.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.ViewModel
{
    public class BaseViewModel : ObservableObject
    {

        public BaseViewModel(IAlertService alertService ) 
        {
            this.alertService= alertService;
            MainInfos = new MainInformations("MixMashter" , "www.MixMashter.net");
        }

        protected IAlertService alertService { get; set;}
        public string MyProjectName { get; set;}
        public DateTime Today { get; } = DateTime.Now;
        public string TodayDate => Today.ToString("d-M-yyyy");
        public MainInformations MainInfos { get; set;}



    }
}
