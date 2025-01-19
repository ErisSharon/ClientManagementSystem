using BmatApplication.Models;

public class ClientsViewModel
{
    public List<ClientsModel> Clients { get; set; } = new List<ClientsModel>(); // For the table
    public ClientsModel NewClient { get; set; } = new ClientsModel(); // For the form
}
