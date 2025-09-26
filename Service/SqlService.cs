using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class SqlService : IDisposable
{
    private readonly string _connectionString;
    private MySqlConnection _connection;

    public SqlService(string connection = null)
    {
        _connectionString = connection ?? "Server=mysql-psi.alwaysdata.net;Port=3306;Database=psi_mysql;Uid=psi;Pwd=Rodrigo1234*;";
        _connection = new MySqlConnection(_connectionString);
        _connection.Open();
    }

    public DataTable ExecuteQueryDataTable(string query)
    {
        MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
        DataTable data = new DataTable();
        adapter.Fill(data);
        return data;
    }

    public int ExecuteNonQuery(string query, Dictionary<string, string> parameters = null)
    {
        using (MySqlCommand cmd = new MySqlCommand(query, _connection))
        {
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            return cmd.ExecuteNonQuery();
        }
    }

    public object ExecuteScalar(string query, Dictionary<string, string> parameters = null)
    {
        using (MySqlCommand cmd = new MySqlCommand(query, _connection))
        {
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            return cmd.ExecuteScalar();
        }
    }

    public int NewCourse(string name, string description)
    {
        var parameters = new Dictionary<string, string>
    {
        { "@name", name },
        { "@description", description }
    };

        return this.ExecuteNonQuery($"INSERT INTO Cursos (nome_curso, descricao_curso) VALUES (@name, @description);", parameters);
    }

    public bool HasCourseByName(string name)
    {
        var parameters = new Dictionary<string, string>
        {
            { "@name", name }
        };

        object result = this.ExecuteScalar("SELECT COUNT(*) FROM Cursos WHERE nome_curso = @name;", parameters);
        return Convert.ToBoolean(result);
    }


    public void Dispose()
    {
        if (_connection != null)
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}