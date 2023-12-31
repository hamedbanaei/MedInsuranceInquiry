﻿using System.Linq;

namespace Domain;

public class Request :
	Seedwork.Entity
{
	#region Constructors
	public Request(string title) : base()
	{
		Title = title;

		RequestDetails =
			new System.Collections.Generic.List<RequestDetail>();
	}
	#endregion /Constructors

	#region Properties
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Title))]

	[System.ComponentModel.DataAnnotations.Required
		(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MinLength
		(length: Constants.MinLength.Title,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MinLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Title,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string Title { get; set; }




	#endregion /Properties

	#region Methods
	public float CalculateCoverage()
	{
		return (RequestDetails.Sum(p => p.CalculateCoverage()));
	}
	#endregion /Methods

	#region Collections
	public virtual System.Collections.Generic.IList<RequestDetail> RequestDetails { get; private set; }
	#endregion /Collections
}