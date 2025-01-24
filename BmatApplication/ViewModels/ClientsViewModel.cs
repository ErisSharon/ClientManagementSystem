using BmatApplication.Models;

namespace BmatApplication.ViewModels
{
    public class ClientsViewModel
    {
        // A list of clients to be displayed in the view
        public List<ClientsModel> Clients { get; set; }

        // Pagination: page number for navigating through large lists
        public int PageNumber { get; set; }

        // Pagination: the total number of clients, used for calculating the number of pages
        public int TotalClients { get; set; }

        // Any other view-specific data, such as sorting options
        public string SortOrder { get; set; }
    }
}