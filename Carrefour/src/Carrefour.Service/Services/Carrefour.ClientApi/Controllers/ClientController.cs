using Carrefour.ClientApi.Interfaces;
using Carrefour.Domain.Interfaces;

namespace Carrefour.ClientApi.Controllers;

public class ClientController : MainController
{
    private readonly IClientService _clientService;
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository, IClientService clientService, INotifier notifier) : base(notifier)
    {
        _clientService = clientService;
        _clientRepository = clientRepository;
    }
}
