namespace Persistence.Configurations;

internal class RequestDetailConfiguration : object,
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.RequestDetail>
{
	public RequestDetailConfiguration() : base()
	{
	}

	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.RequestDetail> builder)
	{
		#region Property(ies) Configuration
		#endregion /Property(ies) Configuration

		#region Index(es) Configuration
		builder
			.HasKey(current => new { current.Id })
			;

		builder
			.HasIndex(current => new { current.RequestId, current.InsuranceServiceId })
			.IsUnique(unique: true)
			;

		#endregion /Index(es) Configuration

		#region Relation(s) Configuration
		#endregion /Relation(s) Configuration

		#region Seed Data
		#endregion /Seed Data
	}
}
