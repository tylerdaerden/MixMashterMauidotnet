using MixMashter.Model.User;
using MixMashter.Model;
using MixMashter.Model.Artists;

namespace MixMashter
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}

        private void buttonCreateUser_Clicked(object sender, EventArgs e)
        {
            User JohnDoe = new User(id: 1, "John", "Doe", "Johndoe",1 , "johndoe@gmail.com", new DateTime(2000, 4, 15), "Test123456789");

            lblDebug.Text = "User Crée";

        }

        private void buttonCreateAdmin_Clicked(object sender, EventArgs e)
        {

            Admin Boss = new Admin(1 ,"Le" , "Boss" , "Leboss" , 2 , "leboss@gmail.com" , new DateTime(1987,11,25) , "Test123456789" , true);

            lblDebug.Text = "Admin Crée";

        }


        private void buttonAccessCsv_Clicked(object sender, EventArgs e)
        {

        }

        private void buttonAccessJson_Clicked(object sender, EventArgs e)
        {

        }
    }

}
