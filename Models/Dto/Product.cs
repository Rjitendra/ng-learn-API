using System;


namespace Models.Dto
{
    public class ProductDto : VersionedDtoBase
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
