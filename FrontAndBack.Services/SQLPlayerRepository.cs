using FrontAndBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAndBack.Services
{
    public class SQLPlayerRepository : IPlayerRepository
    {
        private readonly AppDBContext _context;

        public SQLPlayerRepository(AppDBContext context)
        {
            _context = context;
            
        }

        public Player AddPlayer(Player newPlayer)
        {
            _context.Players.Add(newPlayer);
            _context.SaveChanges();
            return newPlayer;
        }

        public Player DeletePlayer(int id)
        {
            var playerToDelete = _context.Players.Find(id);
            if(playerToDelete != null)
            {
                _context.Players.Remove(playerToDelete);
                _context.SaveChanges();
                return playerToDelete;
            }

            return null;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Players;    
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.Find(id);
        }

        public IEnumerable<RoleHeadCount> PlayerCountByRole(Role? role)
        {
            IEnumerable<Player> query = _context.Players;

            if (role.HasValue)
            {
                query = query.Where(x => x.Role == role.Value);
            }

            return query.GroupBy(x => x.Role)
                            .Select(x => new RoleHeadCount()
                            {
                                Role = x.Key.Value,
                                Count = x.Count()
                            }).ToList();
        }

        public Player UpdatePlayer(Player updatePlayer)
        {
            var player = _context.Players.Attach(updatePlayer);
            player.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatePlayer;
        }
    }
}
