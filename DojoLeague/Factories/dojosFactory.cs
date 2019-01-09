using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using DojoLeague.Models;
using System.Linq;

namespace DojoLeague.Factories {

        public class DojoFactory{
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
            public void CreateDojo(dojos item)
            {
                using(IDbConnection dbConnection = Connection)
                {
                    string query = "INSERT INTO dojos(dojos.name, dojos.location, dojos.description) VALUES(@name, @location, @description)";
                    dbConnection.Open();
                    dbConnection.Execute(query, item);
                }
            }
            public IEnumerable<dojos> GetAll()
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return dbConnection.Query<dojos>("SELECT * FROM dojos").ToList();
                }
            }

            public dojos FindById(int id)
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return dbConnection.Query<dojos>("SELECT * FROM dojos WHERE id = @id", new {Id = id}).FirstOrDefault();
                }
            }
        }

    // public dojos FindById(long id)
    // {
    //     using (IDbConnection dbConnection = Connection)
    //     {
    //         dbConnection.Open();
    //         var query =
    //         @"
    //         SELECT * FROM teams WHERE id = @Id;
    //         SELECT * FROM players WHERE team_id = @Id;
    //         ";
    
    //         using (var multi = dbConnection.QueryMultiple(query, new {Id = id}))
    //         {
    //             Team team = multi.Read<Team>().Single();
    //             team.players = multi.Read<Player>().ToList();
    //             return team;
    //         }
    //     }
    // }
        
}
