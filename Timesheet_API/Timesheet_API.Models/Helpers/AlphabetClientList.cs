using Timesheet_API.Models.Models;

namespace Timesheet_API.Models.Helpers
{
    public class AlphabetClientList
    {
        public string Alphabet { get; set; }
        public List<Client> SubList { get; set; }
    }
}
