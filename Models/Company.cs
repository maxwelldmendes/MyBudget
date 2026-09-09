using MyBudget.Models;

public class Company
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string LegalName { get; set; } = string.Empty;
    public string PrimaryEmailAddress { get; set; } = string.Empty;
    public string PrimaryPhone { get; set; } = string.Empty;
    public string WebAddress { get; set; } = string.Empty;

    public DateTime MetaDataCreateTime { get; set; }
    public DateTime MetaDataLastUpdatedTime { get; set; }

    // Foreign Keys
    public int CompanyAddressId { get; set; }
    public int LegalAddressId { get; set; }

    // Foreign Keys for strict One-to-One
    public Address? CompanyAddress { get; set; }
    public Address? LegalAddress { get; set; }
}
