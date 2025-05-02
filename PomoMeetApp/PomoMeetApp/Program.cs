using PomoMeetApp.Classes;
using PomoMeetApp.View;

namespace PomoMeetApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            FirebaseConfig.SetEnviromentVariable();
            ApplicationConfiguration.Initialize();
            Application.Run(new Friends());
        }
    }
}