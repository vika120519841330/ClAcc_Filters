using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Models;

namespace InfrastructureServices.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientInfrastr>
    {
        public void Configure(EntityTypeBuilder<ClientInfrastr> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(_ => _.ClientId);
        }
    }
}