namespace ERC.UserManagement.Infrastructure.Persistence.Configurations;

internal class LoginHistoryConfigurations : IEntityTypeConfiguration<LoginHistory>
{
    public void Configure(EntityTypeBuilder<LoginHistory> builder)
    {
        builder.HasKey(lh => lh.Id);

        builder.Property(lh => lh.Id)
            .ValueGeneratedOnAdd();

        builder.Property(lh => lh.LoginDate)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(lh => lh.UserAccount)
            .WithMany(u => u.LoginHistories)
            .HasForeignKey(lh => lh.UserAccountId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}