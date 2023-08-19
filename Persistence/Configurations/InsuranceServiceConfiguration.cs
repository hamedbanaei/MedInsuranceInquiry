using System.Data;

namespace Persistence.Configurations;

internal class InsuranceServiceConfiguration : object,
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.InsuranceService>
{
	public InsuranceServiceConfiguration() : base()
	{
	}

	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.InsuranceService> builder)
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
			.WithOne(other => other.InsuranceService)
			.IsRequired(required: true)
			.HasForeignKey(other => other.InsuranceServiceId)
			.OnDelete(deleteBehavior:
				Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			;

		#endregion /Relation(s) Configuration

		#region Seed Data
		var SurgeryService =
		   new Domain.InsuranceService("SurgeryService")
		   {
			   Rate = 0.0052f,
			   MinimumFund = 5000,
			   MaximumFund = 500_000_000,
		   };

		var DentalService =
		   new Domain.InsuranceService("DentalService")
		   {
			   Rate = 0.0042f,
			   MinimumFund = 4000,
			   MaximumFund = 400_000_000,
		   };

		var HospitalizationService =
		   new Domain.InsuranceService("HospitalizationService")
		   {
			   Rate = 0.005f,
			   MinimumFund = 2000,
			   MaximumFund = 200_000_000,
		   };

		builder.HasData(SurgeryService, DentalService, HospitalizationService);
		#endregion /Seed Data
	}
}
