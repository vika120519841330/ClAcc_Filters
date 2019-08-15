using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Models;

namespace InfrastructureServices.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountInfrastr>
    {
        public void Configure(EntityTypeBuilder<AccountInfrastr> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(_ => _.AccountId);
        }
    }
}