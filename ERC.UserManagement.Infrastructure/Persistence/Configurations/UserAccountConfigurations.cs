namespace ERC.UserManagement.Infrastructure.Persistence.Configurations;

internal class UserAccountConfigurations : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(320);

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.RegistrationDate)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");
    }
}