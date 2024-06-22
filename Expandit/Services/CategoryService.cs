using Expandit.Models;
using Microsoft.Data.Sqlite;
 
namespace Expandit.Services
{
	public class CategoryService
	{
		public CategoryService()
		{

		}

		private readonly string connStr = "Data Source=Database.sqlite;";

		public void Add(CategoryModel categoryModel)
		{
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string insertQuery = "INSERT INTO Category (Name) VALUES (@Name)";
				using (var command = new SqliteCommand(insertQuery, connection))
				{
					command.Parameters.AddWithValue("@Name", categoryModel.Name);
					command.ExecuteNonQuery();
				}
			}
		}
		public bool IsNameExists(string name)
		{
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string isUniqueQuery = "SELECT COUNT(*) FROM Category WHERE Name = @Name";
				using (var command = new SqliteCommand(isUniqueQuery, connection))
				{
					command.Parameters.AddWithValue("@Name", name);
					var count = (long)command.ExecuteScalar();
					return count != 0;
				}
			}
		}



		public void Remove(int id)
		{
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string deleteQuery = "DELETE FROM Category WHERE Id = @Id";
				using (var command = new SqliteCommand(deleteQuery, connection))
				{
					command.Parameters.AddWithValue("@Id", id);
					command.ExecuteNonQuery();
				}
			}
		}



		public CategoryModel Get(int id)
		{

			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string selectQuery = "SELECT Id, Name FROM Category WHERE Id = @Id";
				using (var command = new SqliteCommand(selectQuery, connection))
				{
					command.Parameters.AddWithValue("@Id", id);
					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return new CategoryModel
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),
							};
						}
					}
				}
			}
			return null;

		}



		public List<CategoryModel> GetAll()
		{
			var categoryModels = new List<CategoryModel>();
			using (var connection = new SqliteConnection(connStr))
			{
				connection.Open();
				string selectQuery = "SELECT Id, Name FROM Category";
				using (var command = new SqliteCommand(selectQuery, connection))
				{
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var model = new CategoryModel
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),

							};
							categoryModels.Add(model);
						}
					}
				}
			}
			return categoryModels;
		}
	}
}
