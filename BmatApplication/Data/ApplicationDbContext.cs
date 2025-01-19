using Microsoft.EntityFrameworkCore;
using BmatApplication.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ClientsModel> Clients { get; set; }
}
