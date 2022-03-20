namespace DomainLayer.Models.Election
{
    public interface IElectionModel
    {
        int ElectionId { get; set; }
        string ElectionName { get; set; }
        string EndDate { get; set; }
        string StartDate { get; set; }
    }
}