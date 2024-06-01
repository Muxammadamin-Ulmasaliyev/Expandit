﻿using Microsoft.Data.Sqlite;
using Expandit.Models;
using System.Text;

namespace Expandit.Services
{
	public class TextShortcutsService
	{
		public TextShortcutsService()
		{

		}

		private readonly string connStr = "Data Source=TextShortcuts.db;";

		public void Add(TextShortcutModel textShortcutModel)
		{
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string insertQuery = "INSERT INTO TextShortcuts (Name, Key, Value) VALUES (@Name ,@Key, @Value)";
				using (var command = new SqliteCommand(insertQuery, connection))
				{
					command.Parameters.AddWithValue("@Name", textShortcutModel.Name);
					command.Parameters.AddWithValue("@Key", textShortcutModel.Key);
					command.Parameters.AddWithValue("@Value", textShortcutModel.Value);
					command.ExecuteNonQuery();
				}
			}
		}
		public bool IsKeyExists(string key)
		{
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string isUniqueQuery = "SELECT COUNT(*) FROM TextShortcuts WHERE Key = @Key";
				using (var command = new SqliteCommand(isUniqueQuery, connection))
				{
					command.Parameters.AddWithValue("@Key", key);
					var count = (long)command.ExecuteScalar();
					return count != 0;
				}
			}
		}

		public int GetCountShortcutModelsByKey(string key)
		{
			var shortcutModels = new List<TextShortcutModel>();
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string selectQuery = "SELECT Count(*) FROM TextShortcuts WHERE Key = @Key";
				using (var command = new SqliteCommand(selectQuery, connection))
				{
					command.Parameters.AddWithValue("@Key", key);
					var count = (long)command.ExecuteScalar();
					return (int)count;
				}
			}
		}


		public void Remove(int id)
		{
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string deleteQuery = "DELETE FROM TextShortcuts WHERE Id = @Id";
				using (var command = new SqliteCommand(deleteQuery, connection))
				{
					command.Parameters.AddWithValue("@Id", id);
					command.ExecuteNonQuery();
				}
			}
		}


		public void Update(TextShortcutModel modelToUpdate)
		{
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string updateQuery = "UPDATE TextShortcuts SET Name = @Name, Key = @Key, Value = @Value WHERE Id = @Id";
				using (var command = new SqliteCommand(updateQuery, connection))
				{
					command.Parameters.AddWithValue("@Id", modelToUpdate.Id);
					command.Parameters.AddWithValue("@Name", modelToUpdate.Name);
					command.Parameters.AddWithValue("@Key", modelToUpdate.Key);
					command.Parameters.AddWithValue("@Value", modelToUpdate.Value);
					command.ExecuteNonQuery();
				}
			}
		}
		public TextShortcutModel Get(int id)
		{

			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string selectQuery = "SELECT Id, Key, Value FROM TextShortcuts WHERE Id = @Id";
				using (var command = new SqliteCommand(selectQuery, connection))
				{
					command.Parameters.AddWithValue("@Id", id);
					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return new TextShortcutModel
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),
								Key = reader.GetString(2),
								Value = reader.GetString(3)
							};
						}
					}
				}
			}
			return null;

		}



		public List<TextShortcutModel> GetAll()
		{
			var shortcutModels = new List<TextShortcutModel>();
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string selectQuery = "SELECT Id, Name, Key, Value FROM TextShortcuts";
				using (var command = new SqliteCommand(selectQuery, connection))
				{
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var model = new TextShortcutModel
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),
								Key = reader.GetString(2),
								Value = reader.GetString(3)
							};
							shortcutModels.Add(model);
						}
					}
				}
			}
			return shortcutModels;
		}
	}
}
