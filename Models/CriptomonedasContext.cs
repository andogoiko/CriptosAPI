using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Criptomonedas.Models;

public class CriptomonedasContext : DbContext
{
    public CriptomonedasContext(DbContextOptions<CriptomonedasContext> options)
        : base(options)
    {
    }

    public DbSet<Criptomonedas.Models.Criptomoneda> Criptomoneda { get; set; }
}
