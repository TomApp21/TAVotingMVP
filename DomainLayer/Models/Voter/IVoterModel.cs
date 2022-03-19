namespace DomainLayer.Models.Voter
{
    public interface IVoterModel
    {
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string DateOfBirth { get; set; }
        int ElectionId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string NationalInsurance { get; set; }
        string Postcode { get; set; }
    }
}