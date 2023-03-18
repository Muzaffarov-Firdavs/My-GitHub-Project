using Microsoft.EntityFrameworkCore;
using NewGit.Data.Contexts;
using NewGit.Data.IRepositories;
using NewGit.Domain.Entities;

namespace NewGit.Data.Repositories
{
    public class ProgectRepository : IProjectRepository
    {
        private AppDbContext DbContext = new AppDbContext();


        public async ValueTask<bool> DeleteProgectAsync(long id)
        {
            var entity = await DbContext.Progects.FirstOrDefaultAsync(p => p.Id == id);
            if (entity is null)
            {
                return false;
            }

            DbContext.Progects.Remove(entity);
            DbContext.SaveChanges();
            return true;
        }

        public async ValueTask<Project> InsertProgectAsync(Project project)
        {
            var insertedEntity = (await DbContext.Progects.AddAsync(project)).Entity;
            DbContext.SaveChanges();
            return insertedEntity;
        }

        public IQueryable<Project> SelectAllProgectAsync()
        {
            return DbContext.Progects.Where(p => true);
        }

        public async ValueTask<Project> SelectProgectAsync(long id)
        {
            return await DbContext.Progects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async ValueTask<Project> UpdateProgectAsync(Project project)
        {
            var entity = await DbContext.Progects
                .FirstOrDefaultAsync(p => p.Title == project.Title);
            
            if (entity is not null)
            {
                var updatedProgect = DbContext.Progects.Update(project).Entity;
                DbContext.SaveChanges();
                return updatedProgect;
            }

            return null;
        }
    }
}
