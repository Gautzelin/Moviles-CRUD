using Microsoft.Extensions.Logging;

namespace jcorreaS5A
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbPath = FileAccesHelper.GetLocalFolderPath("personas.db");
            builder.Services.AddSingleton<Repositories.PersonRepository>
                (S => ActivatorUtilities.CreateInstance<Repositories.PersonRepository>
                (S, dbPath));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
