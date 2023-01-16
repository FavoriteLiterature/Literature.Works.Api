using Literature.Works.Api.Entities;

namespace Literature.Works.Api.Infrastructure;

public static class DbInitializer
{
    public static async Task Initialize(DataContext context)
    {
        if (!context.DbGenres.Any())
        {
            await context.AddAsync(new Genre {Name = "Экшн"});
            await context.AddAsync(new Genre {Name = "Фантастика"});
            await context.AddAsync(new Genre {Name = "Фанфики"});
        }
        
        if (!context.DbAttachmentTypes.Any())
        {
            await context.AddAsync(new AttachmentType {Name = "Cover"});
            await context.AddAsync(new AttachmentType {Name = "Image"});
            await context.AddAsync(new AttachmentType {Name = "Document"});
        }
        
        await context.SaveChangesAsync();
    }
}