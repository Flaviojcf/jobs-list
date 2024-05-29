using JobsList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsList.Infrastructure.Persistance.Configuration
{
    public class JobsConfiguration : IEntityTypeConfiguration<Jobs>
    {
        public void Configure(EntityTypeBuilder<Jobs> builder)
        {
            builder.HasKey(j => j.Id);
        }
    }
}
