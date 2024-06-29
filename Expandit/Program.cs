<<<<<<< HEAD
using SQLitePCL;
using System.Diagnostics.Metrics;
using System.Threading;
=======
>>>>>>> cd28171602855217b51fa7555c05c2674e89de02

namespace Expandit
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


<<<<<<< HEAD
			const string appName = "Expandit"; 
			bool createdNew;

			var mutex = new Mutex(true, appName, out createdNew);

			if (!createdNew)
			{
				// Another instance is already running
				MessageBox.Show("Another instance of the application is already running.");
				return;
			}

=======
>>>>>>> cd28171602855217b51fa7555c05c2674e89de02
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);




			ApplicationConfiguration.Initialize();
			Application.Run(new MainWindow());

<<<<<<< HEAD
			mutex.ReleaseMutex();
=======

>>>>>>> cd28171602855217b51fa7555c05c2674e89de02

		}

		static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			// Handle the exception
			MessageBox.Show($"An unexpected error occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			// Optionally, log the exception
		}

		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			if (ex != null)
			{
				// Handle the exception
				MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				// Optionally, log the exception
			}
		}
	}
}