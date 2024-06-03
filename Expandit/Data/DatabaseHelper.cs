using Microsoft.Data.Sqlite;

namespace Expandit.Data
{
	public class DatabaseHelper
	{
		private const string DatabaseFileName = "TextShortcuts.db";
		private const string ConnectionString = "Data Source=TextShortcuts.db";

		public static void InitializeDatabase()
		{
			// Check if the database file exists
			if (!File.Exists(DatabaseFileName))
			{
				var connection = new SqliteConnection(ConnectionString);
				connection.Open();
				// The file will be created when we open the connection, so no need to create it manually
				string createCategoryTableQuery = @"CREATE TABLE IF NOT EXISTS ""Category"" (
                                                ""Id"" INTEGER NOT NULL UNIQUE,
                                                ""Name"" TEXT NOT NULL,
                                                PRIMARY KEY(""Id"" AUTOINCREMENT)
                                              )";
				using (var command = new SqliteCommand(createCategoryTableQuery, connection))
				{
					command.ExecuteNonQuery();
				}

				string createTextShortcutsTableQuery = @"CREATE TABLE IF NOT EXISTS ""TextShortcuts"" (
                                                ""Id"" INTEGER NOT NULL UNIQUE,
                                                ""Name"" TEXT NOT NULL,
                                                ""Key"" TEXT NOT NULL UNIQUE,
                                                ""Value"" TEXT NOT NULL,
                                                ""CategoryId"" INTEGER NULL,
                                                PRIMARY KEY(""Id"" AUTOINCREMENT),
                                                FOREIGN KEY(""CategoryId"") REFERENCES ""Category""(""Id"")
                                              )";
				using (var command = new SqliteCommand(createTextShortcutsTableQuery, connection))
				{
					command.ExecuteNonQuery();
				}
				connection.Close();
			}
		}
	}
}
