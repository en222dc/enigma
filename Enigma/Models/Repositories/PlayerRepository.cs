using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Npgsql;

namespace Enigma.Models.Repositories
{
    class PlayerRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["sup_db4"].ConnectionString;

        #region CREATE
        public static Player AddNewPlayerToDb(Player newPlayer)
        {
            string stmt = "INSERT INTO player (player_name) VALUES (@player_name) RETURNING player_id";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (var command = new NpgsqlCommand(stmt, conn))
                        {
                            command.Parameters.AddWithValue("player_name", newPlayer.Player_name);
                            int id = (int)command.ExecuteScalar();
                            newPlayer.Player_id = id;
                        }
                        trans.Commit();
                        return newPlayer;
                    }
                    catch (PostgresException)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion

        #region READ

        //string stmt = "SELECT player_name, time FROM player INNER JOIN highscore ON  player_id = fk_player_id ORDER BY highscore DESC

        public static IEnumerable<Player> GetPlayers()
        {
            string stmt = "SELECT player_id, player_name FROM player ORDER BY player_id;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Player player = null;
                List<Player> players = new List<Player>();
                conn.Open();

                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            player = new Player()
                            {
                                Player_id = (int)reader["player_id"],
                                Player_name = (string)reader["player_name"],
                            };
                            players.Add(player);
                        }
                    }
                }

                return players;
            }
        }

        #endregion
    }
}
