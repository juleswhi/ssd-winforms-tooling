using System.Diagnostics;
using FormSystem.Forms;

namespace UsingStateExample;

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
        ApplicationConfiguration.Initialize();
        // Remove the normal, `Application.Run(new formMaster)` with the following:

        Start<formLogin>();
    }
}