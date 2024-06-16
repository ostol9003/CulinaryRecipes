using API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Helpers;

namespace API.DTO

{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public static implicit operator Category(CategoryDto dto)
            => new Category().CopyProperties(dto);
        public static implicit operator CategoryDto(Category ctg)
                    => new CategoryDto().CopyProperties(ctg);

    }
}
