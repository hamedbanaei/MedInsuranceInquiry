namespace Infrastructure.Settings;

public class ApplicationSettings : object
{
	public static readonly string KeyName = nameof(ApplicationSettings);

	public ApplicationSettings() : base()
	{
		CultureSettings =
			new CultureSettings();
	}

	public CultureSettings CultureSettings { get; set; }
}
