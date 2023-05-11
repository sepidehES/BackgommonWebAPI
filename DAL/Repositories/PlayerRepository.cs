using DAL.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDbConnection _Connection;

        public PlayerRepository(IDbConnection connection)
        {
            _Connection = connection;
        }

        private void AddParameter(IDbCommand command, string name, object data)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = data ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
        private Player Convert(IDataRecord record)
        {
            return new Player(
                (int)record["PlayerId"],
                (string)record["Pseudo"],
                (string)record["Email"],
                (string)record["Password_Hash"]
                );
        }

        public Player Create(Player players)
        {
            string query = "INSERT INTO [Player] (Pseudo, Email, Password_Hash)"
                + "OUTPUT [inserted].*"
                + "VALUES(@Pseudo,@Email,@Password_Hash)";

            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            AddParameter(command, "Pseudo", players.Pseudo);
            AddParameter(command, "Email", players.Email);
            AddParameter(command, "Password_Hash", players.Password_Hash);

            Player? playersCreated = null;

            try
            {
                _Connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        playersCreated = Convert(reader);
                    }
                }
            } 
            finally
            {
                _Connection.Close();
            }

            return playersCreated;
        }


        public bool Delete(int playerId)
        {
            //    IDbCommand cmd = _Connection.CreateCommand();
            //    cmd.CommandText = "DELETE FROM [Player] WHERE [PlayerId] = @playerId";
            return true;
        }

        public Player? GetById(int id)
        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "SELECT * FROM [Player] WHERE [PlayerId] = @id;";
            command.CommandType = CommandType.Text;

            AddParameter(command, "id", id);

            Player? player = null;

            _Connection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    player = Convert(reader);
                }
            }
            _Connection.Close();

            return player;
        }

    }
    
}
