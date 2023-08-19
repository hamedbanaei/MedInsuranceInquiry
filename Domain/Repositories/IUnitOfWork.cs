namespace Domain.Repositories;

public interface IUnitOfWork : System.IDisposable
{
	IRequestRepository Requests { get; }

	IRequestDetailRepository RequestDetails { get; }

	IInsuranceServiceRepository InsuranceServices { get; }

	int Complete();
}
