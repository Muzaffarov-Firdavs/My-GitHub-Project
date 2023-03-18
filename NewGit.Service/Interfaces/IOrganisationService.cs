using NewGit.Domain.Entities;
using NewGit.Service.Helpers;

namespace NewGit.Service.Interfaces
{
    public interface IOrganisationService
    {
        ValueTask<Response<Organisation>> AddOrganisationAsync(Organisation organisation);
        ValueTask<Response<bool>> DeleteOrganisationAsync(long id);
        ValueTask<Response<Organisation>> UpdateOrganisationAsync(long id, Organisation organisation);
        ValueTask<Response<Organisation>> GetOrganisationByIdAsync(long id);
        ValueTask<Response<List<Organisation>>> GetAllOrganisationAsync();
    }
}
