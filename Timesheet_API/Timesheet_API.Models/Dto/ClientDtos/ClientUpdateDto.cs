namespace Timesheet_API.Models.Dto.ClientDtos
{
    public class ClientUpdateDto
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
