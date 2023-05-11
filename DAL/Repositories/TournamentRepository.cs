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
    public class TournamentRepository : ITournamentRepository
    {
        private readonly IDbConnection _Connection;

        public TournamentRepository(IDbConnection connection)
        {
            _Connection = connection; 
        }

        private Tournament Convert(IDataRecord record)
        {
            return new Tournament(
                (int)record["TournamentId"],
                (string)record["TournamentName"],
                (string)record["Description"],
                (int)record["MaxPlayer"]
            );
        }

        private void AddParameter(IDbCommand command, string name, object data)
        {
            IDbDataParameter cmd = command.CreateParameter();
            cmd.ParameterName = name;
            cmd.Value = data ?? DBNull.Value;
            command.Parameters.Add(cmd);
        }

        public Tournament? Create(Tournament tournament)
        {
            string query = "INSERT INTO [Tournament] (TournamentName, Description, MaxPlayer)"
                + " OUTPUT [inserted].*"
                + " VALUES(@TournamentName, @Description, @MaxPlayer)";

            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            AddParameter(command, "TournamentName", tournament.TournamentName);
            AddParameter(command, "Description", tournament.Description);
            AddParameter(command, "MaxPlayer", tournament.MaxPlayer);


            Tournament? tournamentCreated = null;

            try
            {
                _Connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tournamentCreated = Convert(reader);
                    }
                }
            }
            finally
            {
                _Connection.Close();
            }

            return tournamentCreated;
        }

        public IEnumerable<Tournament> GetAll()
        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "SELECT * FROM [Tournament];";
            command.CommandType = CommandType.Text;

            _Connection.Open();

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return Convert(reader);
                }
            }

            _Connection.Close();
        }

        public Tournament? GetById(int tournamentId)
        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "SELECT * FROM [Tournament] WHERE [TournamentId] = @id;";
            command.CommandType = CommandType.Text;

            AddParameter(command, "id", tournamentId);

            Tournament? tournament = null;

            _Connection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    tournament = Convert(reader);
                }
            }
            _Connection.Close();

            return tournament;
        }

        public bool Delete(int tournamentId)
        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "DELETE FROM [Tournament] WHERE [tournamentId] = @Id";
            command.CommandType = CommandType.Text;

            AddParameter(command, "Id", tournamentId);

            _Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            _Connection.Close();

            return nbRow == 1;
        }
    }
}
