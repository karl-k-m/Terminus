using Microsoft.EntityFrameworkCore;
using Terminus.Models;

namespace Terminus.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Node> Nodes { get; set; }
    }
}