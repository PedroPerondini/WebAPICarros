using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPICarros.Domain.Model
{
    public class CarroDbContext : DbContext
    {
        public CarroDbContext(DbContextOptions<CarroDbContext> options) : base(options)
        { }

        public DbSet<CarroModel> CarroModels { get; set; } = null!;
    }
}
