using Models.Dto;
using Models.Entities;
using System;
using System.Reflection;
using System.Text.Json;


namespace Services.Mapper
{
    public static class JsonEntityMapper
    {
        public static TEntity ToEntity<TDto, TEntity>(TDto dto)
            where TDto : VersionedDtoBase
            where TEntity : BaseEntity, new()
        {
            return new TEntity
            {
                JsonDoc = SerializeOwnProperties(dto), // 🔹 Only derived props
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = dto.UpdatedDate ?? DateTime.UtcNow,
                IsValid = dto.IsValid,
                IsVisible = dto.IsVisible ?? true,
                IsDeleted = dto.IsDeleted ?? false,
                IsLatestVersion = dto.IsLatestVersion ?? true,
                BaseVersionId = dto.BaseVersionId,
                VersionId = dto.VersionId,
                StatusId = dto.StatusId,
                PkId = dto.PkId ?? Guid.NewGuid()
            };
        }

        public static TDto ToDto<TDto>(BaseEntity entity)
            where TDto : VersionedDtoBase
        {
            var dto = JsonSerializer.Deserialize<TDto>(entity.JsonDoc);
            if (dto == null) throw new Exception("Invalid JsonDoc");
            dto.UpdatedBy = entity.UpdatedBy;
            dto.UpdatedDate = entity.UpdatedDate;
            dto.IsValid = entity.IsValid;
            dto.IsVisible = entity.IsVisible;
            dto.IsDeleted = entity.IsDeleted;
            dto.IsLatestVersion = entity.IsLatestVersion;
            dto.BaseVersionId = entity.BaseVersionId;
            dto.VersionId = entity.VersionId;
            dto.StatusId = entity.StatusId;
            dto.PkId = entity.PkId;
            dto.Id = entity.Id;
            return dto;
        }

        public static string SerializeOwnProperties<T>(T dto)
        {
            var derivedType = typeof(T);
            var baseType = derivedType.BaseType;

            var ownProps = derivedType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .ToDictionary(p => p.Name, p => p.GetValue(dto));

            return JsonSerializer.Serialize(ownProps);
        }

    }

}