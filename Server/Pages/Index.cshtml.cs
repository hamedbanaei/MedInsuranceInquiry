using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;

namespace Server.Pages
{
	public class IndexModel : PageModel
	{
		public IndexModel(Persistence.DatabaseContext context)
		{
			Context = context;
		}
		Persistence.DatabaseContext Context { get; }

		public void OnGet()
		{
			using (var unit = new UnitOfWork(Context))
			{
				unit.Requests.GetAllAsync();
			}
		}
	}
}
