namespace Timesheet_API.Models.Dto.ProjectTaskDtos
{
    public class ProjectTaskPostDto
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Time { get; set; }
        public decimal Overtime { get; set; }
        public DateTime Date { get; set; }
    }
}
