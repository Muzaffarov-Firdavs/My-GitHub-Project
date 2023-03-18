using Microsoft.EntityFrameworkCore;
using NewGit.Data.Contexts;
using NewGit.Data.IRepositories;
using NewGit.Domain.Entities;

namespace NewGit.Data.Repositories
{
    public class OrganisationRepository : IOrganisationRepository
    {
        AppDbContext DbContext = new AppDbContext();

        public async ValueTask<bool> DeleteOrganisationAsync(long id)
        {
            var organisatoin = await DbContext.Organisations
                .FirstOrDefaultAsync(o => o.Id == id);
            if (organisatoin is null)
                return false;

            DbContext.Organisations.Remove(organisatoin);
            DbContext.SaveChanges();
            return true;
        }

        public async ValueTask<Organisation> InsertOrganisationAsync(
                                            Organisation organization)
        {
            var insertedOrganisation = (await DbContext.Organisations
                                            .AddAsync(organization)).Entity;
            DbContext.SaveChanges();
            return insertedOrganisation;
        }

        public async ValueTask<IQueryable<Organisation>> SelectAllOrganisationAsync()
        {
            return DbContext.Organisations.Where(e => true);
        }

        public async ValueTask<Organisation> SelectOrganisationAsync(long id)
        {
            return await DbContext.Organisations.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async ValueTask<Organisation> UpdateOrganisationAsync(Organisation organization)
        {
            var clarifiedOrganisation = await DbContext.Organisations
                    .FirstOrDefaultAsync(o => o.Id == organization.Id);
            if (clarifiedOrganisation is not null)
            {
                var updatedOrganisation = (DbContext.Organisations.Update(organization)).Entity;
                DbContext.SaveChanges();
                return updatedOrganisation;
            }

            return null;
        }
    }
}