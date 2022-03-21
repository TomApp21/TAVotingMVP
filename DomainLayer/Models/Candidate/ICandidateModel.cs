namespace DomainLayer.Models.Candidate
{
    public interface ICandidateModel
    {
        int CandidateId { get; set; }
        string CandidateName { get; set; }
        int ElectionId { get; set; }
        int VoteCount { get; set; }
    }
}