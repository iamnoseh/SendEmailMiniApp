using Domain.Entities.AdModels;
using Domain.Entities.EmailDomains;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> option):DbContext(option)
{ 
    public DbSet<Ad> Ads {get; set; }
}
