using System.Collections.Generic;
using System.Threading.Tasks;

namespace RugbyManager.API.Utilities
{
    public interface ISecurity
    {
        Task<string> GenerateJWTokenAsync(string user, IList<string> roles);
    }
}
