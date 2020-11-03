using RugbyManager.API.DataAccessLayer;
using RugbyManager.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.Managers
{
    public class TeamManager : ITeamManager
    {
        private readonly IRugbyManagerAccess _managerAccess;

        public TeamManager(IRugbyManagerAccess managerAccess)
        {
            _managerAccess = managerAccess;
        }

        public async Task AddTeamAsync(TeamModel team)
        {
            await _managerAccess.AddTeamAsync(team);
        }
    }
}
