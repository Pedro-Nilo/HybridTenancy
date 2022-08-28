namespace Hybrid.Tenancy.Api.Models.Commom;

public class AppTenant
{
    public AppTenant(Guid registerNumber)
    {
        RegisterNumber = registerNumber;
    }

    public Guid RegisterNumber { get; }
}
