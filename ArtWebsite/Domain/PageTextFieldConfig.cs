using ArtWebsite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtWebsite.Domain
{
    public class PageTextFieldConfig : IEntityTypeConfiguration<PageTextField>
    {
        public void Configure(EntityTypeBuilder<PageTextField> builder)
        {
            builder.HasData(new PageTextField
            {
                Id = new Guid("a84960d3-3bc1-4711-a950-3f6dae23e2d9"),
                CodeWord = "Index",
                Title = "Home page"
            });

            builder.HasData(new PageTextField
            {
                Id = new Guid("d1074f46-afe8-4cc1-b878-339de094487a"),
                CodeWord = "Gallery",
                Title = "Gallery page"
            });

            builder.HasData(new PageTextField
            {
                Id = new Guid("15efadf2-e767-43fd-98d9-9b267e2de763"),
                CodeWord = "PaintingInfo",
                Title = "Painting"
            });

            builder.HasData(new PageTextField
            {
                Id = new Guid("13ef8f78-e9d5-4afa-8d7a-89776be89a4d"),
                CodeWord = "AuthorInfo",
                Title = "Author"
            });
        }
    }
}
