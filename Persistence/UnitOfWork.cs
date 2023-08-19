using Domain.Repositories;
using Persistence.Repositories;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
	private readonly DatabaseContext _context;

	public UnitOfWork(DatabaseContext context)
	{
		_context = context;

		Requests = new RequestRepository(_context);
		RequestDetails = new RequestDetailRepository(_context);
		InsuranceServices = new InsuranceServiceRepository(_context);
	}

	public IRequestRepository Requests { get; private set; }

	public IRequestDetailRepository RequestDetails { get; private set; }

	public IInsuranceServiceRepository InsuranceServices { get; private set; }

	public int Complete()
	{
		return _context.SaveChanges();
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
