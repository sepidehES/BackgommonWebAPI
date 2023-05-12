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
    public class MatchRepository : IMatchRepository
    {
        private readonly IDbConnection _Connection;
        public MatchRepository(IDbConnection connection)
        {
            _Connection = connection;
        }

        private void AddParameter(IDbCommand command, string name, object data)
        {
            IDbDataParameter cmd = command.CreateParameter();
            cmd.ParameterName = name;
            cmd.Value = data ?? DBNull.Value;
            command.Parameters.Add(cmd);
        }

        private Match Convert(IDataRecord record)
        {
            return new Match(
                (int)record["MatchId"],
                (DateTime)record["DateStart"],
                (DateTime)record["DateEnd"],
                (int)record["Player1Id"],
                (int)record["Player2Id"],
                (int)record["TournamentId"]


            );
        }
        public Match? GetById(int matchId)

        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "SELECT * FROM [Match] WHERE [MatchId] = @id";
            command.CommandType = CommandType.Text;

            AddParameter(command, "id", matchId);

            Match? match = null;

            _Connection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    match = Convert(reader);
                }
            }
            _Connection.Close();

            return match;
        }
    }
    
}
