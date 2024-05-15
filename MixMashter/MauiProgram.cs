using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MixMashter.Utilities.DataAccess;
using MixMashter.Utilities.DataAccess.Files;
using MixMashter.Utilities.Interfaces;
using MixMashter.Utilities.Services;
using MixMashter.View;
using MixMashter.ViewModel;

namespace MixMashter
{
    public static class MauiProgram
    {
        //config file pour portable ↓↓↓ pour Cconfig file 
        private const string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MixMashter\MixMashter\Configuration\Datas\Config.txt";

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

            //injection datafilemanager 
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);     

            #region Rappel Definition AddSingleton
            /*
            Services.AddSingleton() permet de faire de l'injection de dépendance dans le constructeur des ViewModel par exemple
            sans devoir faire un new DataAccessJsonFile() dans celui-ci
            une instance est créée à ce stade et rendue disponible dans les constructeurs des classes. L'instance est permanente pour la méthode AddSingleton
            tandis qu'elle est recréée à chaque fois qu'on en a besoin quand on fait du .AddTransient()
            Les Services doivent être vu comme un conteneur de services disponibles ailleurs. Il contient toutes les instances spécifiées dans les <>
            */ 
            #endregion


            //Singletons
            builder.Services.AddSingleton<IAlertService>(new AlertServiceDisplay());
            builder.Services.AddSingleton<IDataAccess>(new DataAccessJsonFiles(dataFilesManager));

            //injection dependance des pageviewmodel en mode Transient (c’est-à-dire transitoire), instance disponible pour tout le projet, mais recrée à chaque demande (c’est la nuance avec Singleton).
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<TracksPage>();
            builder.Services.AddTransient<TracksPageViewModel>();
            builder.Services.AddTransient<ArtistsPage>();
            builder.Services.AddTransient<ArtistsPageViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
