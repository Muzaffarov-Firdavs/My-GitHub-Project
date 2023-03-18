using NewGit.Data.IRepositories;
using NewGit.Data.Repositories;
using NewGit.Domain.Entities;
using NewGit.Service.Helpers;
using NewGit.Service.Interfaces;

namespace NewGit.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository = new ProgectRepository();

        public async ValueTask<Response<Project>> AddProjectAsync(Project project)
        {
            var clarifyingModel = projectRepository.SelectAllProgectAsync()
                .Where(p => p.OwnerId == project.OwnerId)
                .Take(1)
                .ToList();

            if (clarifyingModel is null)
                return new Response<Project>
                {
                    Code = 400,
                    Message = "Project name is already taken"
                };

            var addedProject = await projectRepository.InsertProgectAsync(project);
            return new Response<Project>
            {
                Code = 200,
                Message = "Success",
                Value = addedProject
            };
        }

        public async ValueTask<Response<bool>> RemoveProgectAsync(long id)
        {
            var clarifyingId = await projectRepository.SelectProgectAsync(id);
            if (clarifyingId is null)
                return new Response<bool>
                {
                    Code = 404,
                    Message = "Not found",
                    Value = false
                };

            bool result = await projectRepository.DeleteProgectAsync(id);
            return new Response<bool>
            {
                Code = 200,
                Message = "Success",
                Value = result
            };
        }

        public async ValueTask<Response<List<Project>>> GetAllProjectAsync()
        {
            var projets = projectRepository.SelectAllProgectAsync().ToList();
            return new Response<List<Project>>
            {
                Code = 200,
                Message = "Success",
                Value = projets
            };
        }

        public async ValueTask<Response<Project>> GetProjectByIdAsync(long id)
        {
            var entity = await projectRepository.SelectProgectAsync(id);
            if (entity is null)
                return new Response<Project>
                {
                    Code = 404,
                    Message = "Not found",
                    Value = null
                };

            return new Response<Project>
            {
                Code = 200,
                Message = "Success",
                Value = entity
            };
        }

        public async ValueTask<Response<Project>> ModifyProjectAsync(long id, Project project)
        {
            var clarifiedModel = await projectRepository.SelectProgectAsync(id);
            if (clarifiedModel is null)
                return new Response<Project>
                {
                    Code = 404,
                    Message = "Not found",
                    Value = null
                };
            var updatedProject = await projectRepository.UpdateProgectAsync(project);

            return new Response<Project>
            {
                Code = 200,
                Message = "Success",
                Value = updatedProject
            };
        }
    }
}
