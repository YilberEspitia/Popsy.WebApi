using Microsoft.EntityFrameworkCore;

namespace Popsy
{
    /// <summary>
    /// DbContext para manejo de entidades.
    /// </summary>
    public sealed partial class PopsyDbContext : DbContext
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">Referencia de <see cref="DbContextOptions"/></param>
        public PopsyDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
