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
            try
            {
                FirebaseConfig.SetEnviromentVariable();
                ApplicationConfiguration.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new StartApp());
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // ??m b?o t?t c? process ???c ?óng
                Environment.Exit(0);
            }
        }
    }
}