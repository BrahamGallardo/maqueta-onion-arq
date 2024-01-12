using Onion.Arq.Application.Models;

namespace Onion.Arq.Application.Interfaces.Services
{
    public interface ISessionAsyncService
    {
        Task<SessionDto> GetSessionAsync(string email, string pwd);
    }
}
