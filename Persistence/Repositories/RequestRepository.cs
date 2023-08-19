using Domain;
using Domain.Repositories;

namespace Persistence.Repositories;

public class RequestRepository : Repository<Request>, IRequestRepository
{
	public RequestRepository(DatabaseContext context)
			: base(context)
	{
	}
}
