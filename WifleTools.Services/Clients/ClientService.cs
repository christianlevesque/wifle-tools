using WifleTools.Infrastructure;

namespace WifleTools.Clients;

public class ClientService : CrudService<Client>
{
	/// <inheritdoc />
	public ClientService(
		AppDbContext dbContext,
		IStatusLogger<CrudService<Client>> statusLogger)
		: base(dbContext, statusLogger) {}
}