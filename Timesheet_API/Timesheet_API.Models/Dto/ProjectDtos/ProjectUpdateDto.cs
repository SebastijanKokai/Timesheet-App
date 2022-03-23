namespace Timesheet_API.Models.Dto.ProjectDtos
{
    public class ProjectUpdateDto
    {
        public Guid Id { get; set; }
        public Guid ClientID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectStatus { get; set; }
    }
}
