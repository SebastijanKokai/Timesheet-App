namespace Timesheet_API.Models.Dto.ProjectDtos
{
    public class ProjectPostDto
    {
        public Guid ClientID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectStatus { get; set; } 
    }
}
