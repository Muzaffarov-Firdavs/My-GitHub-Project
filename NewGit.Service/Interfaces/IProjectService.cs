using NewGit.Domain.Entities;
using NewGit.Service.Helpers;

namespace NewGit.Service.Interfaces
{
    public interface IProjectService
    {
        ValueTask<Response<Project>> AddProjectAsync(Project project);
        ValueTask<Response<bool>> RemoveProgectAsync(long id);
        ValueTask<Response<Project>> ModifyProjectAsync(long id, Project project);
        ValueTask<Response<Project>> GetProjectByIdAsync(long id);
        ValueTask<Response<List<Project>>> GetAllProjectAsync();
    }
}
