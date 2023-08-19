using Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;

var webApplicationOptions =
	new Microsoft.AspNetCore.Builder.WebApplicationOptions
	{
		EnvironmentName =
			System.Diagnostics.Debugger.IsAttached ?
			Microsoft.Extensions.Hosting.Environments.Development
			:
			Microsoft.Extensions.Hosting.Environments.Production,
	};

var builder =
	Microsoft.AspNetCore.Builder
	.WebApplication.CreateBuilder(options: webApplicationOptions);

builder.Services.AddHttpContextAccessor();

builder.Services.AddRouting(options =>
{
	options.LowercaseUrls = true;
	options.LowercaseQueryStrings = true;
});

builder.Services.AddRazorPages();

builder.Services.Configure<Infrastructure.Settings.ApplicationSettings>
	(builder.Configuration.GetSection(key: Infrastructure.Settings.ApplicationSettings.KeyName))
	.AddSingleton
	(implementationFactory: serviceType =>
	{
		var result =
			// GetRequiredService()-> using Microsoft.Extensions.DependencyInjection;
			serviceType.GetRequiredService
			<Microsoft.Extensions.Options.IOptions
			<Infrastructure.Settings.ApplicationSettings>>().Value;

		return result;
	});

var connectionString =
	builder.Configuration.GetConnectionString(name: "ConnectionString");

builder.Services.AddDbContext<Persistence.DatabaseContext>
	(optionsAction: options =>
	{
		options
			.UseLazyLoadingProxies();

		options
			.UseSqlServer(connectionString: connectionString);
	});

var app =
	builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else	
{
	app.UseGlobalException();
	
	app.UseExceptionHandler("/Errors/Error");
	
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCultureCookie();

app.MapRazorPages();

app.Run();
