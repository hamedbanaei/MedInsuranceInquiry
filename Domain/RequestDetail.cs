using System.Text.RegularExpressions;

namespace Domain;

public class RequestDetail :
	Seedwork.Entity
{
	#region Constructors
	public RequestDetail() : base()
	{
	}
	#endregion /Constructors

	#region Properties
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Request))]
	public System.Guid? RequestId { get; set; }



	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Request))]
	public virtual Request? Request { get; set; }



	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.InsuranceService))]
	public string? InsuranceServiceId { get; set; }



	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.InsuranceService))]
	public virtual InsuranceService? InsuranceService { get; set; }



	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.MaximumFund))]

	[System.ComponentModel.DataAnnotations.Required
		(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.Range
		(minimum: Constants.MinValue.Fund,
		maximum: Constants.MaxValue.Fund,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
	public long Fund { get; set; }
	#endregion /Properties

	#region Methods
	public float CalculateCoverage()
	{
		return ((float)Fund / InsuranceService.Rate);
	}
	#endregion /Methods

	#region Collections
	#endregion /Collections
}
