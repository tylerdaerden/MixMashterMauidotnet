﻿using MixMashter.Model.User;
using MixMashter.Model;

namespace MixMashter
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void buttonCreateUser_Clicked(object sender, EventArgs e)
        {
            User JohnDoe = new User(id : 1 ,"John" , "Doe", "Johndoe" ,"johndoe@gmail.com" , DateTime.Now , "Test1234");

            lblDebug.Text = "User Crée";

        }

        private void buttonCreateAdmin_Clicked(object sender, EventArgs e)
        {

            Admin Boss = new Admin(1 ,"Le" , "Boss" , "Leboss" , "leboss@gmail.com" , DateTime.Now , "Test1234" , true);

            lblDebug.Text = "Admin Crée";

        }

        private void buttonCreateMasher_Clicked(object sender, EventArgs e)
        {
            Masher MasherPotato = new Masher(1 , "Masher" , "Potato" , "Mashedpotato", "MashedPotato@gmail.com" , DateTime.Now , "Test1234" , true);

            lblDebug.Text = "Masher Crée";

        }
    }

}
