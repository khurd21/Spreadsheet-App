/// <summary>
/// Program to run Unique application.
/// </summary>
/// <copyright file="Program.cs" company="WSU Cpts 321"></copyright>

namespace Unique;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new UniqueForm());
    }    
}