using FrontAndBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAndBack.Services
{
    public class MockPlayerRepository : IPlayerRepository
    {
        private List<Player> _playerList;

        public MockPlayerRepository()
        {
            _playerList = new List<Player>()
            {
                new Player(){
                    ID = 0,
                    Name = "Mary",
                    Email = "mary@gmail.com",
                    PhotoPath = "avatar2.png",
                    Role = Models.Role.User
                },

            new Player() {
                ID = 1,
                Name = "Jack",
                Email = "jack@gmail.com",
                PhotoPath = "avatar5.png",
                Role = Models.Role.User
                },

                new Player(){
                    ID = 2,
                    Name = "Jhon",
                    Email = "jhon@gmail.com",
                    PhotoPath = "noimage.png",
                    Role = Models.Role.User
                },

                new Player(){
                    ID = 3,
                    Name = "Kate",
                    Email = "kate@gmail.com",
                    PhotoPath = "avatar3.png",
                    Role = Models.Role.Expert
                },

                new Player(){
                    ID = 4,
                    Name = "Bruce",
                    Email = "bruce@gmail.com",
                    PhotoPath = "avatar.png",
                    Role = Models.Role.Expert
                },

                new Player(){
                    ID = 5,
                    Name = "Maya",
                    Email = "maya@gmail.com",
                    Role = Models.Role.User
                }
            };
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _playerList;
        }

        public Player GetPlayerById(int id)
        {
            return _playerList.FirstOrDefault(x => x.ID == id);

        }
    }
}
