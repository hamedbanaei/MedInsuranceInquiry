namespace Infrastructure.Middlewares;

public class CultureCookieHandlerMiddleware : object
{
	#region Static Member(s)
	public readonly static string CookieName = "Culture.Cookie";

	public static string? GetCultureNameByCookie
		(Microsoft.AspNetCore.Http.HttpContext httpContext,
		System.Collections.Generic.IList<string>? supportedCultureNames)
	{
		if (supportedCultureNames == null ||
			supportedCultureNames.Count == 0)
		{
			return null;
		}

		var cultureName =
			httpContext.Request.Cookies[key: CookieName];

		if (string.IsNullOrWhiteSpace(cultureName))
		{
			return null;
		}

		if (supportedCultureNames == null ||
			supportedCultureNames.Contains(cultureName) == false)
		{
			return null;
		}

		return cultureName;
	}

	public static void SetCulture(string? cultureName)
	{
		if (string.IsNullOrWhiteSpace(cultureName) == false)
		{
			var cultureInfo =
				new System.Globalization.CultureInfo(name: cultureName);

			System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
			System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}
	}

	public static void CreateCookie
		(Microsoft.AspNetCore.Http.HttpContext httpContext, string cultureName)
	{
		var cookieOptions =
			new Microsoft.AspNetCore.Http.CookieOptions
			{
				Path = "/",
				Secure = false,
				HttpOnly = false,
				IsEssential = false,
				MaxAge = null,
				Expires = System.DateTimeOffset.UtcNow.AddYears(1),
				SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Unspecified,
			};

		httpContext.Response.Cookies.Delete(key: CookieName);

		if (string.IsNullOrWhiteSpace(cultureName) == false)
		{
			httpContext.Response.Cookies.Append
				(key: CookieName, value: cultureName, options: cookieOptions);
		}
	}
	#endregion /Static Member(s)

	public CultureCookieHandlerMiddleware
		(Microsoft.AspNetCore.Http.RequestDelegate next,
		Settings.ApplicationSettings applicationSettings)
		: base()
	{
		Next = next;
		
		ApplicationSettings = applicationSettings;
	}

	private Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

	private Settings.ApplicationSettings ApplicationSettings { get; }

	public async System.Threading.Tasks.Task InvokeAsync
		(Microsoft.AspNetCore.Http.HttpContext httpContext)
	{
		var defaultCultureName =
			ApplicationSettings.CultureSettings.DefaultCultureName;

		var supportedCultureNames =
			ApplicationSettings.CultureSettings.SupportedCultureNames;

		var currentCultureName =
			GetCultureNameByCookie
			(httpContext: httpContext,
			supportedCultureNames: supportedCultureNames);

		if (currentCultureName == null)
		{
			currentCultureName = defaultCultureName;
		}

		SetCulture(cultureName: currentCultureName);
		
		await Next(context: httpContext);
	}
}
