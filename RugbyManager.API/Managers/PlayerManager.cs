using Microsoft.Extensions.Logging;
using RugbyManager.API.DataAccessLayer;
using RugbyManager.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly ILogger<PlayerManager> _logger;
        private readonly IRugbyManagerAccess _managerAccess;

        public PlayerManager(ILogger<PlayerManager> logger, IRugbyManagerAccess managerAccess)
        {
            _logger = logger;
            _managerAccess = managerAccess;
        }

        public async Task AddPlayerAsync(PlayerModel player)
        {
            await _managerAccess.AddPlayerAsync(player);
        }


    }
}
