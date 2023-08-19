namespace Domain.Seedwork;

public abstract class Entity : object,
	Hbx.Seedwork.Abstractions.IEntity<System.Guid>
{
	#region Constructor(s)
	public Entity() : base()
	{
		InsertDateTime =
			System.DateTime.UtcNow;

		Id =
			System.Guid.NewGuid();
	}
	#endregion /Constructor(s)

	#region Property(ies)

	#region Id Property
	/// <summary>
	/// Identity
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Id))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; protected set; }
	#endregion /Id Property

	#region InsertDateTime Property
	/// <summary>
	/// Exact time that the record created.
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.InsertDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTime InsertDateTime { get; private set; }
	#endregion /InsertDateTime Property

	#endregion /Property(ies)
}
