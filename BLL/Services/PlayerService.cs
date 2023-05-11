using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using Domain.Models;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BLL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public int? Login(int playerId, string password_Hash)
        {
            Player? players = _playerRepository.GetById(playerId);
            if (players == null)
            {
                return null;
            }
            if (!Argon2.Verify(players.Password_Hash, password_Hash))
            {
                return null;
            }
            return players.PlayerId;
        }

        public Player? Create(Player player)
        {
            Player playerSecure = new Player(
                player.Pseudo,
                player.Email,
                Argon2.Hash(player.Password_Hash)
                );
            return _playerRepository.Create(playerSecure);
        }

        public bool Delete(int PlayerId)
        {
            return _playerRepository.Delete(PlayerId);
        }

        public Player? GetById(int PlayerId)
        {
            return _playerRepository.GetById(PlayerId);
        }

       
    }
}
