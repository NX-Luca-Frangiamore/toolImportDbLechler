

using System.Data.SqlClient;

IEnumerable<string> GetCommands(string fileName)
{
    using (var sr = new StreamReader(fileName))
    {
        var command = sr.ReadToEnd().Split(";").ToList();
        foreach(var c in command)
            yield return "begin "+c+" commit";
    }
}

bool RunCommand(string connectionString, string query)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        return reader.RecordsAffected > 0;
    }
}


var your_password = "9cRuYZSj9n0yelbkOcV4f2UAR5";
var connectionString = $"Server=tcp:lechler-dev-core-azsql-server.database.windows.net,1433;Initial Catalog=lechler_dev_map_ns;Persist Security Info=False;User ID=core-azsql-admin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

foreach (var command in GetCommands(connectionString))
    Console.WriteLine(command)
    //Console.Write(RunCommand(connectionString, command));