namespace MTA.Domain.Interfaces;

public interface ICurrentTenant
{
    string? TenantId { get; set; }
    public Task<bool> SetTenant(string tenant);
}