

using System.Data.SqlClient;

async Task<bool> RunQuery(string connectionString, string query)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.FieldCount);

        }
        return reader.FieldCount>0;
    }
    return false;
}


var your_password = "9cRuYZSj9n0yelbkOcV4f2UAR5";
var connectionString = $"Server=tcp:lechler-dev-core-azsql-server.database.windows.net,1433;Initial Catalog=lechler_dev_map_ns;Persist Security Info=False;User ID=core-azsql-admin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

RunQuery(connectionString, "select *  from [dbo].[PersonalFormula]");