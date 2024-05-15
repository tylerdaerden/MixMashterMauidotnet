using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMashter.Utilities.Interfaces
{
    public interface IAlertService
    {
        //Show alert with a title and a message
        Task ShowAlert(string title , string message);

        //Show Confirmation message style YES or NO
        Task<bool> ShowConfirmation(string title , string message);

        // Show alert with a pop up display with a list of button (multiple choices)
        Task<string> ShowQuestion(string title , params string[] buttons);


    }
}
