using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using DojoLeague.Models;
using System.Linq;

namespace DojoLeague.Factories 
{
    public class NinjaFactory{
            static string server = "localhost";
            static string db = "dojoleague"; //Change to your schema name
            static string port = "3306"; //Potentially 8889
            static string user = "root";
            static string pass = "root";
            internal static IDbConnection Connection {
                get {
                    return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
                }
            }

            public void CreateNinja(ninjas item)
            {
                using(IDbConnection dbConnection = Connection)
                {
                    string query = "INSERT INTO ninjas(name, level, description, dojos_id) VALUES(@name, @level, @description, @dojos_id)";
                    dbConnection.Open();
                    dbConnection.Execute(query, item);
                }
            }

            public IEnumerable<ninjas> GetAll()
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return dbConnection.Query<ninjas>("SELECT * FROM ninjas LEFT JOIN dojos ON ninjas.dojos_id = dojos.id").ToList();
                }
            }

            public ninjas FindById(int id)
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return dbConnection.Query<ninjas>("SELECT * FROM ninjas WHERE id = @id", new {Id = id}).FirstOrDefault();
                }
            }

    }



















}