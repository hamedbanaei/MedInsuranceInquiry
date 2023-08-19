using Domain;
using Domain.Repositories;

namespace Persistence.Repositories;

public class RequestDetailRepository : Repository<RequestDetail>, IRequestDetailRepository
{
	public RequestDetailRepository(DatabaseContext context)
			: base(context)
	{
	}
}
