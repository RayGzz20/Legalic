using AutoMapper;
using LawyerApi.DTOs;
using LawyerApi.Models;
using LawyerApi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;

namespace LawyerApi.Endpoints
{
    public static class SpecialtyEndpoints
    {
        public static RouteGroupBuilder MapSpecialty(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllSpecialty).CacheOutput(c => c.Expire(TimeSpan.FromHours(1)).Tag("specialty-getAll"));
            group.MapGet("/{id:int}", GetByIdSpecialty);
            group.MapPost("/", CreateSpecialty);
            group.MapPut("/{id:int}", UpdateSpecialty);
            group.MapDelete("/{id:int}", DeleteSpecialty);
            return group;
        }

        static async Task<Ok<List<SpecialtyDTO>>> GetAllSpecialty (ISpecialtyRepository repository, IMapper mapper) 
        { 
            var list = await repository.GetAll();
            var listSpecialtyDTO = mapper.Map<List<SpecialtyDTO>>(list);
            return TypedResults.Ok(listSpecialtyDTO);
        }

        static async Task<Results<Ok<SpecialtyDTO>, NotFound>> GetByIdSpecialty (int id, ISpecialtyRepository repository, IMapper mapper)
        {
            if (!await repository.Exist(id))
                    return TypedResults.NotFound();

            var specialty = await repository.GetById(id);
            var specialtyDTO = mapper.Map<SpecialtyDTO>(specialty);
            return TypedResults.Ok(specialtyDTO);
        }

        static async Task<Created<SpecialtyDTO>> CreateSpecialty (CreateSpecialtyDTO createSpecialtyDTO, 
        ISpecialtyRepository repository, 
        IOutputCacheStore outputCacheStore, IMapper mapper)
        {
            var specialty = mapper.Map<Specialty>(createSpecialtyDTO);
            var Id = await repository.Create(specialty);
            await outputCacheStore.EvictByTagAsync("specialty-getAll", default);

            var specialtyDTO = mapper.Map<SpecialtyDTO>(specialty);
            return TypedResults.Created($"/specialty/{Id}", specialtyDTO);
        }

        static async Task<Results<NoContent, NotFound>> UpdateSpecialty (int id, CreateSpecialtyDTO createSpecialtyDTO, 
        ISpecialtyRepository repository, 
        IOutputCacheStore outputCacheStore,
        IMapper mapper)
        {
            if (!await repository.Exist(id))
                return TypedResults.NotFound();

            var specialty = mapper.Map<Specialty>(createSpecialtyDTO);
            specialty.SpecialtyId = id;

            await repository.Update(specialty);
            await outputCacheStore.EvictByTagAsync("specialty-getAll", default);
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound>> DeleteSpecialty (int id, ISpecialtyRepository repository, IOutputCacheStore outputCacheStore)
        {
            if (!await repository.Exist(id))
                return TypedResults.NotFound();

            await repository.Delete(id);
            await outputCacheStore.EvictByTagAsync("specialty-getAll", default);
            return TypedResults.NoContent();
        }
    }
}