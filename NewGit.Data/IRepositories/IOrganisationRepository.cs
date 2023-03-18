using NewGit.Domain.Entities;

namespace NewGit.Data.IRepositories
{
    public interface IOrganisationRepository
    {
        ValueTask<Organisation> InsertOrganisationAsync(Organisation organization);
        ValueTask<bool> DeleteOrganisationAsync(long id);
        ValueTask<Organisation> UpdateOrganisationAsync(Organisation organization);
        ValueTask<Organisation> SelectOrganisationAsync(long id);
        ValueTask<IQueryable<Organisation>> SelectAllOrganisationAsync();
    }
}
