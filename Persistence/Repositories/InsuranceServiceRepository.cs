using Domain;
using Domain.Repositories;

namespace Persistence.Repositories;

public class InsuranceServiceRepository : Repository<InsuranceService>, IInsuranceServiceRepository
{
	public InsuranceServiceRepository(DatabaseContext context)
			: base(context)
	{
	}
}
