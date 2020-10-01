using System;
using System.Collections.Generic;
using System.Configuration;
using Npgsql;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Enigma.Models.Repositories
{
    /// <summary>
    /// The Class Repository handles the connection with the database.
    /// </summary>
    class Repository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["sup_db4"].ConnectionString;

        #region CREATE
        /// <summary>
        /// Adds the new player to the database by using Player_name from the class Player
        /// </summary>
        /// <param name="newPlayer"></param>
        /// <returns></returns>
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
                        throw; 
                    }
                }
            }
        }

        /// <summary>
        /// Adds an new highsscore to the database by using Fk_Player_id and Time from the class Highscore
        /// </summary>
        /// <param name="newHighscore"></param>
        /// <returns></returns>
        public static Highscore AddHighScoreToDb(Highscore newHighscore)
        {
            string stmt = "INSERT INTO highscore(fk_player_id, time) VALUES(@fk_player_id, @time) RETURNING highscore_id";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (var command = new NpgsqlCommand(stmt, conn))
                        {
                            command.Parameters.AddWithValue("fk_player_id", newHighscore.Fk_Player_id);
                            command.Parameters.AddWithValue("time", newHighscore.Time);

                            int id = (int)command.ExecuteScalar();
                            newHighscore.Highscore_id = id;
                        }
                        trans.Commit();
                        return newHighscore;
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
        /// <summary>
        /// Gets all highscores from the database, order by time ascending.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Highscore> GetHighscoresFromDb()
        {
            string stmt = "SELECT time, player_name FROM player INNER JOIN highscore ON player_id = fk_player_id ORDER BY time ASC";
            int place = 1;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Highscore highscore = null;
                List<Highscore> highscores = new List<Highscore>();
                conn.Open();

                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            highscore = new Highscore()
                            {
                                Time = (int)reader["time"],
                                Player_name = (string)reader["player_name"],
                                PlaceInHighScoreList = place,
                            };
                            highscores.Add(highscore);
                            place++;
                        }
                    }
                }
                return highscores;
            }
        }

        /// <summary>
        /// Gets all players from the database, order by player_id descending so that the last player added, will have first place in the list.
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Player> GetAllPlayersFromDb()
        {
            string stmt = "SELECT player_name, player_id FROM player ORDER BY player_id DESC;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Player player = null;
                ObservableCollection<Player> allPlayers = new ObservableCollection<Player>();
                conn.Open();

                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player = new Player()
                            {
                                Player_name = (string)reader["player_name"],
                                Player_id = (int)reader["player_id"]
                            };
                            allPlayers.Add(player);
                        }
                    }
                }
                return allPlayers;
            }
        }

        /// <summary>
        /// Gets players from the database, ordered by count.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Player> GetTopPlayersFromDb()
        {
            string stmt = "SELECT player_name, COUNT(*) AS number_of_games FROM player INNER JOIN highscore on player_id = fk_player_id GROUP BY player_name, player_id ORDER BY COUNT(*) DESC;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Player player = null;
                List<Player> topPlayers = new List<Player>();
                conn.Open();

                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player = new Player()
                            {
                                Player_name = (string)reader["player_name"],
                            };
                            topPlayers.Add(player);
                        }
                    }
                }
                return topPlayers;
            }
        }

        /// <summary>
        /// Gets all suspects from the database, with suspect_name and suspect_portrait.
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Suspect> GetAllSuspectsFromDb()
        {
            string stmt = "SELECT suspect_name, suspect_portrait FROM suspect;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Suspect suspect = null;
                ObservableCollection<Suspect> allSuspects = new ObservableCollection<Suspect>();
                conn.Open();

                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string portraitPath = reader["suspect_portrait"].ToString();
                            BitmapImage glowIcon = new BitmapImage();
                            glowIcon.BeginInit();
                            glowIcon.UriSource = new Uri(portraitPath, UriKind.Relative);

                            suspect = new Suspect()
                            {
                                KillerName = (string)reader["suspect_name"],
                                KillerPortrait = glowIcon,
                            };
                            allSuspects.Add(suspect);
                        }
                    }
                }
                return allSuspects;
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Deletes the chosen player from the database. The highscores linked to that player will be deleated as well, using on delete cascade.
        /// </summary>
        /// <param name="myPlayerId"></param>
        public static void DeleteChosenPlayerFromDb(int myPlayerId)
        {
            string stmt = "DELETE FROM player WHERE player_id = @player_id";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("player_id", myPlayerId);
                    command.Prepare();
                    command.ExecuteScalar();
                }
            }
        }
        #endregion
    }
}
