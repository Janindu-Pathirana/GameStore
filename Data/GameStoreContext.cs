using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Entities.Game> Game => Set<Entities.Game>();
    public DbSet<Entities.Genre> Genre => Set<Entities.Genre>();
}
