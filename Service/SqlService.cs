using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

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

    #region Helpers

    public bool IsConnectionOpen()
    {
        return _connection.State == ConnectionState.Open;
    }

    public async Task<DataTable> ExecuteQueryDataTable(string query)
    {
        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();

        MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
        DataTable data = new DataTable();
        await adapter.FillAsync(data);
        return data;
    }

    public async Task<int> ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
    {
        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();

        using (MySqlCommand cmd = new MySqlCommand(query, _connection))
        {
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            return await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task<object> ExecuteScalar(string query, Dictionary<string, object> parameters = null)
    {
        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();

        using (MySqlCommand cmd = new MySqlCommand(query, _connection))
        {
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            return await cmd.ExecuteScalarAsync();
        }
    }

    public async Task<DbDataReader> ExecuteReader(string query, Dictionary<string, object> parameters = null)
    {
        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();

        MySqlCommand cmd = new MySqlCommand(query, _connection);

        if (parameters != null)
        {
            foreach (var p in parameters)
                cmd.Parameters.AddWithValue(p.Key, p.Value);
        }

        return await cmd.ExecuteReaderAsync();
    }

    #endregion
    #region Course Region

    public async Task<DataTable> DataTableFromCourses()
    {
        return await this.ExecuteQueryDataTable("SELECT * FROM Cursos");
    }

    public async Task<Dictionary<int, string>> GetCourseIdAndName()
    {
        var result = new Dictionary<int, string>();

        using (DbDataReader reader = await ExecuteReader("SELECT curso_id, nome_curso FROM Cursos").ConfigureAwait(false))
        {
            int cursoIdIndex = reader.GetOrdinal("curso_id");
            int nomeCursoIndex = reader.GetOrdinal("nome_curso");

            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                int id = reader.GetInt32(cursoIdIndex);
                string name = reader.GetString(nomeCursoIndex);

                result[id] = name;
            }
        }

        return result;
    }

    public async Task<int> NewCourse(string name, string description)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@name", name },
            { "@description", description }
        };

        return await this.ExecuteNonQuery($"INSERT INTO Cursos (nome_curso, descricao_curso) VALUES (@name, @description);", parameters);
    }

    public async Task<int> DeleteCourse(int courseId)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@curso_id", courseId }
        };

        return await ExecuteNonQuery("DELETE FROM Cursos WHERE curso_id = @curso_id", parameters);
    }

    public async Task<int> UpdateCourse(int id, string name, string description)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@id", id },
            { "@name", name },
            { "@description", description }
        };

        return await this.ExecuteNonQuery(
            $"UPDATE Cursos AS c " +
            $"SET c.nome_curso = @name, c.descricao_curso = @description " +
            $"WHERE c.curso_id = @id;",
            parameters
        );
    }

    public async Task<bool> HasCourseByName(string name)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@name", name }
        };

        object result = await this.ExecuteScalar("SELECT COUNT(*) FROM Cursos WHERE nome_curso = @name;", parameters);
        return Convert.ToBoolean(result);
    }

    #endregion
    #region Student Region

    public async Task<DataTable> DataTableFromStudents()
    {
        return await this.ExecuteQueryDataTable("SELECT * FROM Alunos;");
    }

    public async Task<int> NewStudent(string name, string email, string phone, DateTime birth)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@name", name },
            { "@email", email },
            { "@phone", phone},
            { "@birth", birth }
        };

        return await this.ExecuteNonQuery(
            $"INSERT INTO Alunos (nome_aluno, email, telefone, data_nascimento) " +
            $"VALUES (@name, @email, @phone, @birth);",
            parameters
        );
    }

    public async Task<int> DeleteStudent(int studentId)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@id", studentId }
        };

        return await ExecuteNonQuery("DELETE FROM Alunos WHERE aluno_id = @id", parameters);
    }

    public async Task<int> UpdateStudent(int id, string name, string email, string phone, DateTime birth)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@id", id },
            { "@name", name },
            { "@email", email },
            { "@phone", phone},
            { "@birth", birth }
        };

        return await this.ExecuteNonQuery(
            $"UPDATE Alunos AS c " +
            $"SET c.nome_aluno = @name, c.email = @email, c.telefone = @phone, c.data_nascimento = @birth " +
            $"WHERE c.aluno_id = @id;",
            parameters
        );
    }

    public async Task<bool> HasStudentByName(string name)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@name", name }
        };

        object result = await this.ExecuteScalar("SELECT COUNT(*) FROM Alunos WHERE nome_aluno = @name;", parameters);
        return Convert.ToBoolean(result);
    }

    #endregion
    #region Classes Region

    public async Task<DataTable> DataTableFromClasses()
    {
        return await this.ExecuteQueryDataTable(
            "SELECT class.turma_id, class.codigo_turma, class.curso_id, course.nome_curso " +
            "FROM Turmas AS class " +
            "LEFT JOIN Cursos AS course " +
            "ON course.curso_id = class.curso_id;"
        );
    }

    public async Task<int> NewClass(string code, DateTime? year, int? courseId)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@code", code },
            { "@year", year.HasValue ? year.Value : (object)DBNull.Value },
            { "@courseId", courseId.HasValue ? courseId.Value : (object)DBNull.Value }
        };

        return await this.ExecuteNonQuery(
            "INSERT INTO Turmas (codigo_turma, ano_referencia, curso_id) " +
            "VALUES (@code, @year, @courseId);",
            parameters
        );
    }

    public async Task<int> DeleteClass(int classId)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@id", classId }
        };

        return await this.ExecuteNonQuery(
            "DELETE FROM Turmas WHERE turma_id = @id;",
            parameters
        );
    }

    public async Task<int> UpdateClass(int id, string code, DateTime? year, int? courseId)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@id", id },
            { "@code", code },
            { "@year", year.HasValue ? year.Value : (object)DBNull.Value },
            { "@courseId", courseId.HasValue ? courseId.Value : (object)DBNull.Value }
        };

        return await this.ExecuteNonQuery(
            "UPDATE Turmas AS t " +
            "SET t.codigo_turma = @code, t.ano_referencia = @year, t.curso_id = @courseId " +
            "WHERE t.turma_id = @id;",
            parameters
        );
    }

    public async Task<bool> HasClassByCode(string code)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@code", code }
        };

        object result = await this.ExecuteScalar(
            "SELECT COUNT(*) FROM Turmas WHERE codigo_turma = @code;",
            parameters
        );

        return Convert.ToInt32(result) > 0;
    }

    #endregion

    public void Dispose()
    {
        if (_connection != null)
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}