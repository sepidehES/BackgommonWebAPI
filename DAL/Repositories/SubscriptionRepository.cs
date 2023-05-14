using DAL.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IDbConnection _Connection;

        public SubscriptionRepository(IDbConnection connection)
        {
            _Connection = connection;
        }

        private TournamentUser Convert(IDataRecord record)
        {
            return new TournamentUser(
                (int)record["TournamentId"],
                (int)record["PlayerId"]

            );
        }

        private void AddParameter(IDbCommand command, string name, object data)
        {
            IDbDataParameter cmd = command.CreateParameter();
            cmd.ParameterName = name;
            cmd.Value = data ?? DBNull.Value;
            command.Parameters.Add(cmd);
        }
        public TournamentUser? Create(TournamentUser tournamentUser)
        {
            string query = "INSERT INTO [TournamentUser] (TournamentId, PlayerId)"
                + " OUTPUT [inserted].*"
                + " VALUES(@TournamentId, @PlayerId)";

            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            AddParameter(command, "TournamentId", tournamentUser.TournamentId);
            AddParameter(command, "PlayerId", tournamentUser.PlayerId);
 
            TournamentUser? tournamentCreated = null;

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
    }
    
}
