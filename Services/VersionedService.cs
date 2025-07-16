using Models.Dto;
using Models.Entities;
using Models.Enums;
using Services.Mapper;


namespace Services
{
    public class VersionedService<TDto, TEntity> : IVersionedService<TDto, TEntity>
    where TDto : VersionedDtoBase
    where TEntity : BaseEntity, new()
    {
        private readonly IRepository<TEntity> _repo;

        public VersionedService(IRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            var filtered = entities
                          .Where(e => !e.IsDeleted && e.IsLatestVersion);

            return filtered.Select(JsonEntityMapper.ToDto<TDto>);

        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);

            return entity == null ? null : JsonEntityMapper.ToDto<TDto>(entity);
        }

        public async Task<TDto> SaveAsync(TDto dto)
        {
            var allVersions = (await _repo.GetAllAsync())
                .Where(x => x.PkId == dto.PkId)
                .OrderByDescending(x => x.VersionId)
                .ToList();

            var previous = allVersions.FirstOrDefault();

            // Mark old versions as not latest
            foreach (var version in allVersions)
            {
                version.IsLatestVersion = false;
                await _repo.UpdateAsync(version.Id, version);
            }

            var entity = JsonEntityMapper.ToEntity<TDto, TEntity>(dto);
            entity.PkId = previous?.PkId ?? Guid.NewGuid();
            entity.VersionId = previous?.VersionId + 1 ?? 1;
            entity.BaseVersionId = previous?.BaseVersionId + 1 ?? 0;
            entity.IsValid = dto.IsValid;
            entity.IsDeleted = dto.OperationType == OperationType.Delete;
            entity.IsLatestVersion = true;
            entity.UpdatedDate = DateTime.UtcNow;

            entity.UpdatedBy = "jitu";
            entity.StatusId = 1;

            var saved = await _repo.AddAsync(entity);
            var latestData =await _repo.GetByIdAsync(saved.Id);
            return JsonEntityMapper.ToDto<TDto>(saved);
        }

        public async Task<TDto?> DiscardDraftAsync(TDto dto)
        {
            var all = (await _repo.GetAllAsync())
                .Where(x => x.PkId == dto.PkId)
                .OrderByDescending(x => x.VersionId)
                .ToList();

            var drafts = all.Where(x => !x.IsValid).ToList();
            foreach (var draft in drafts)
                await _repo.DeleteAsync(draft.Id);

            var lastValid = all.FirstOrDefault(x => x.IsValid && !x.IsDeleted);
            if (lastValid != null)
            {
                lastValid.IsLatestVersion = true;
                await _repo.UpdateAsync(lastValid.Id, lastValid);
                return JsonEntityMapper.ToDto<TDto>(lastValid);
            }

            return null;
        }
    }
}