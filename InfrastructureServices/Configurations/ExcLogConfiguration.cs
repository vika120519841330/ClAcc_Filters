using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Models;

namespace InfrastructureServices.Configurations
{
    public class ExcLogConfiguration : IEntityTypeConfiguration<ExceptionInfra>
    {
        public void Configure(EntityTypeBuilder<ExceptionInfra> builder)
        {
            builder.ToTable("ExceptionLogEntries");

            builder.HasKey(_ => _.ExcId);
        }
    }
}