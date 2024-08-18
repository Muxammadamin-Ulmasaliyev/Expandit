using Expandit.Data;
using System.Diagnostics.Metrics;
using System.Threading;

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


			bool createdNew;

			var mutex = new Mutex(true, GlobalVariables.APP_NAME, out createdNew);

			if (!createdNew)
			{
				// Another instance is already running
				MessageBox.Show("Another instance of the application is already running.");
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);




			ApplicationConfiguration.Initialize();
			Application.Run(new MainWindow());

			mutex.ReleaseMutex();

		}

		static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			// Handle the thread exception
			MessageBox.Show($"An unexpected error occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			// Optionally, log the exception
			LogException(e.Exception);
		}

		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			if (ex != null)
			{
				// Handle the unhandled exception
				MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				// Optionally, log the exception
				LogException(ex);
			}
		}

		static void LogException(Exception ex)
		{
			string logFilePath = "error_log.txt"; // Specify the log file path
			using (StreamWriter writer = new StreamWriter(logFilePath, true))
			{
				writer.WriteLine($"[{DateTime.Now}] Exception: {ex.Message}");
				writer.WriteLine(ex.StackTrace);
				if (ex.InnerException != null)
				{
					writer.WriteLine($"Inner Exception: {ex.InnerException.Message}");
					writer.WriteLine(ex.InnerException.StackTrace);
				}
				writer.WriteLine();
			}
		}
	}
}