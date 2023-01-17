using AutoMapper;
using Literature.Works.Api.Application.Queries.Genres;
using Literature.Works.Api.Entities;
using Literature.Works.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Literature.Works.Api.Tests;

public class GetGenresListRequestHandlerTests
{
    [Test]
    [TestCase(0, 0, 0, ExpectedResult = 0)]
    [TestCase(5, 0, 5, ExpectedResult = 5)]
    [TestCase(0, 5, 5, ExpectedResult = 0)]
    [TestCase(0, 4, 5, ExpectedResult = 0)]
    [TestCase(1, 4, 5, ExpectedResult = 1)]
    public async Task<int> AddGenresTest(int take, int skip, int modelsCount)
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var serviceCollection = new ServiceCollection()
            .AddAutoMapper(typeof(Startup).Assembly)
            .BuildServiceProvider();
        var mapper = serviceCollection.GetRequiredService<IMapper>();
        await using var context = new DataContext(options);

        for (int i = 0; i < modelsCount; i++)
        {
            context.Add(new Genre
            {
                Name = Guid.NewGuid().ToString()
            });
            await context.SaveChangesAsync();
        }

        var handler = new GetGenresListRequestHandler(context, mapper);
        var request = new GetGenresListRequest
        {
            Take = take,
            Skip = skip
        };
        var result = await handler.Handle(request, CancellationToken.None);
        return result.Items.Count;
    }
}
