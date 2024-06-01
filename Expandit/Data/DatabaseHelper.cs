using System.IO;
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
				// The file will be created when we open the connection, so no need to create it manually
				using (var connection = new SqliteConnection(ConnectionString))
				{
					connection.Open();
					string createTableQuery = @"CREATE TABLE ""TextShortcuts"" (
                                                ""Id"" INTEGER NOT NULL UNIQUE,
                                                ""Name"" TEXT NOT NULL,
                                                ""Key"" TEXT NOT NULL UNIQUE,
                                                ""Value"" TEXT NOT NULL,
                                                PRIMARY KEY(""Id"" AUTOINCREMENT)
                                              )";
					using (var command = new SqliteCommand(createTableQuery, connection))
					{
						command.ExecuteNonQuery();
					}
				}
			}
		}
	}
}
