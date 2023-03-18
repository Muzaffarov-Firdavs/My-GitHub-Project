using NewGit.Domain.Entities;

namespace NewGit.Data.IRepositories
{
    public interface IProjectRepository
    {
        ValueTask<Project> InsertProgectAsync(Project project);
        ValueTask<bool> DeleteProgectAsync(long id);
        ValueTask<Project> UpdateProgectAsync(Project project);
        ValueTask<Project> SelectProgectAsync(long id);
        IQueryable<Project> SelectAllProgectAsync();
    }
}
