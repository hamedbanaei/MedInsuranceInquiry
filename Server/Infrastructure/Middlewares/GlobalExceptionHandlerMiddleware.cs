namespace Infrastructure.Middlewares;

public class GlobalExceptionHandlerMiddleware : object
{
	public GlobalExceptionHandlerMiddleware
		(Microsoft.AspNetCore.Http.RequestDelegate next,
		Hbx.Logging.ILogger<GlobalExceptionHandlerMiddleware> logger) : base()
	{
		Next = next;
		Logger = logger;
	}

	private Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

	private Hbx.Logging.ILogger<GlobalExceptionHandlerMiddleware> Logger { get; set; }

	public async System.Threading.Tasks.Task
		InvokeAsync(Microsoft.AspNetCore.Http.HttpContext httpContext)
	{
		try
		{
			await Next(httpContext);
		}
		catch (System.Exception ex)
		{
			Logger.LogCritical(ex, ex.ToString());

			httpContext.Response.Redirect
				(location: "/Errors/Error500", permanent: false);
		}
	}
}
