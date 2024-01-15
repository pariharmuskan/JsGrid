using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JsGrid.Models
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
    }
}
