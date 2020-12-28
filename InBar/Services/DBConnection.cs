using System;
using Npgsql;

namespace InBar.Services
{
    public class DBConnection
    {
        private static NpgsqlConnection _connection;

        private static DBConnection _instance;

        public static void Connect()
        {
            CreateDbIfNotExist();
            CreateUserTableIfNotExist();
        }

        private static void CreateConnection()
        {
            var ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=password;Database=InBarDatabase;";

            try
            {
                _connection = new NpgsqlConnection(ConnectionString);
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void CreateDbIfNotExist()
        {
            var connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=password;";

            _connection = new NpgsqlConnection(connStr);
            var m_createdb_cmd = new NpgsqlCommand(@"
                CREATE DATABASE IF NOT EXISTS InBarDatabase
                WITH OWNER = postgres
                ENCODING = 'UTF8'
                CONNECTION LIMIT = -1;
                ", _connection);
            try
            {
                _connection.Open();
                m_createdb_cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void CreateUserTableIfNotExist()
        {
            CreateConnection();
            var cmd = new NpgsqlCommand();
            cmd.Connection = _connection;

            try
            {
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS user(email text NOT NULL,userId integer NOT NULL GENERATED ALWAYS AS IDENTITY(INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 256),password text NOT NULL,PRIMARY KEY('userId'))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO user(userId, email, password) VALUES(1,'user@mail.ru','user')";
                cmd.ExecuteNonQuery();
                _connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
