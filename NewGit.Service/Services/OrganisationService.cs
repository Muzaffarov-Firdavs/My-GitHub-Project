using NewGit.Data.IRepositories;
using NewGit.Data.Repositories;
using NewGit.Domain.Entities;
using NewGit.Service.Helpers;
using NewGit.Service.Interfaces;

namespace NewGit.Service.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationRepository organisationRepository = new OrganisationRepository();

        public async ValueTask<Response<Organisation>> AddOrganisationAsync(Organisation organisation)
        {
            var organisations = (await organisationRepository   
                                    .SelectAllOrganisationAsync()).ToList();
            var checkingOrganisation = organisations
                            .FirstOrDefault(o => o.Name == organisation.Name);
            if (checkingOrganisation is null)
                return new Response<Organisation>()
                {
                    Code = 403,
                    Message = "Organisation is already created"
                };

            var addedOrganisation = await organisationRepository
                                    .InsertOrganisationAsync(organisation);
            return new Response<Organisation>
            {
                Code = 200,
                Message = "Success",
                Value = addedOrganisation
            };
        }

        public async ValueTask<Response<bool>> DeleteOrganisationAsync(long id)
        {
            var organisation = await organisationRepository.SelectOrganisationAsync(id);
            if (organisation is null)
                return new Response<bool>
                {
                    Code = 404,
                    Message = "Not found",
                    Value = false
                };
            await organisationRepository.DeleteOrganisationAsync(organisation.Id);
            return new Response<bool>
            {
                Code = 200,
                Message = "Success",
                Value = true
            };
        }

        public async ValueTask<Response<List<Organisation>>> GetAllOrganisationAsync()
        {
            var entities = (await organisationRepository.SelectAllOrganisationAsync()).ToList();
            return new Response<List<Organisation>>
            {
                Code = 200,
                Message = "Success",
                Value = entities
            };
        }

        public async ValueTask<Response<Organisation>> GetOrganisationByIdAsync(long id)
        {
            var organisation = await organisationRepository.SelectOrganisationAsync(id);

            if (organisation is null)
                return new Response<Organisation>
                {
                    Code = 404,
                    Message = "Not found"
                };

            return new Response<Organisation>
            {
                Code = 200,
                Message = "Success",
                Value = organisation
            };
        }

        public async ValueTask<Response<Organisation>> UpdateOrganisationAsync(
                                                        long id, Organisation organisation)
        {
            var checkingOrganisation = await organisationRepository.SelectOrganisationAsync(id);
            if (checkingOrganisation is null)
                return new Response<Organisation>
                {
                    Code = 404,
                    Message = "Not found"
                };

            var updatedOrganisation = await organisationRepository
                                                .UpdateOrganisationAsync(organisation);
            return new Response<Organisation>
            {
                Code = 200,
                Message = "Success",
                Value = updatedOrganisation
            };
        }
    }
}