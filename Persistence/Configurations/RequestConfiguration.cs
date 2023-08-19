using System.Data;

namespace Persistence.Configurations;

internal class RequestConfiguration : object,
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Request>
{
	public RequestConfiguration() : base()
	{
	}
	
	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Request> builder)
	{
		#region Property(ies) Configuration
		builder
			.Property(current => current.Title)
			.IsUnicode(unicode: true)
			;

		#endregion /Property(ies) Configuration

		#region Index(es) Configuration
		builder
			.HasKey(current => new { current.Id })
			;

		#endregion /Index(es) Configuration

		#region Relation(s) Configuration
		builder
			.HasMany(current => current.RequestDetails)
			.WithOne(other => other.Request)
			.IsRequired(required: true)
			.HasForeignKey(other => other.RequestId)
			.OnDelete(deleteBehavior:
				Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			;

		#endregion /Relation(s) Configuration

		#region Seed Data
		#endregion /Seed Data
	}
}
