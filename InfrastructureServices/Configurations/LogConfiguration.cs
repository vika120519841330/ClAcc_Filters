using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Models;

namespace InfrastructureServices.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<RequestLogEntry>
    {
        public void Configure(EntityTypeBuilder<RequestLogEntry> builder)
        {
            builder.ToTable("Logs");

            builder.HasKey(_ => _.UserId);
        }
    }
}