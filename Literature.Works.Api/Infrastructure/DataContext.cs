using Literature.Works.Api.Entities;
using Literature.Works.Api.Entities.Abstractions;
using Literature.Works.Api.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api.Infrastructure;

public class DataContext : DbContext, IDataContext, IRepository
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    #region DbSet

    public DbSet<Work> DbWorks { get; set; }
    public DbSet<Genre> DbGenres { get; set; }
    public DbSet<GenreWork> DbGenreWorks { get; set; }
    public DbSet<Author> DbAuthors { get; set; }
    public DbSet<Attachment> DbAttachments { get; set; }
    public DbSet<AttachmentType> DbAttachmentTypes { get; set; }

    #endregion

    #region IQueryable

    public IQueryable<Work> Works => DbWorks;
    public IQueryable<Genre> Genres => DbGenres;
    public IQueryable<Author> Authors => DbAuthors;
    public IQueryable<Attachment> Attachments => DbAttachments;
    public IQueryable<AttachmentType> AttachmentTypes => DbAttachmentTypes;

    #endregion

    public new async Task AddAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : BaseEntity
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        await base.AddAsync(entity, token);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GenreWork>().HasKey(gw => new { gw.GenreId, gw.WorkId });
        
        modelBuilder.Entity<GenreWork>()
            .HasOne(g => g.Genre)
            .WithMany(gw => gw.Works)
            .HasForeignKey(gi => gi.GenreId);
        
        modelBuilder.Entity<GenreWork>()
            .HasOne(w => w.Work)
            .WithMany(gw => gw.Genres)
            .HasForeignKey(wi => wi.WorkId);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}