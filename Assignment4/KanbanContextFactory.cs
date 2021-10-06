using System;
using System.IO;
using Assignment4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using static Assignment4.Core.State;

public class KanbanContextFactory : IDesignTimeDbContextFactory<KanbanContext>

{
    public KanbanContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<Program>()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Superheroes");

        var optionsBuilder = new DbContextOptionsBuilder<KanbanContext>()
            .UseSqlServer(connectionString);

        return new KanbanContext(optionsBuilder.Options);
    }
}
