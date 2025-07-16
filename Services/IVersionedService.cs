using Models.Dto;
namespace Services
{
    using Models.Entities;
    public interface IVersionedService<TDto, TEntity>
        where TDto : VersionedDtoBase
        where TEntity : BaseEntity
    {
        Task<TDto> SaveAsync(TDto dto);
        Task<TDto?> DiscardDraftAsync(TDto dto);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);
    }
}