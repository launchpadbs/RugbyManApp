using RugbyManager.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.Managers
{
    public interface IPlayerManager
    {
        Task AddPlayerAsync(PlayerModel player);
    }
}
