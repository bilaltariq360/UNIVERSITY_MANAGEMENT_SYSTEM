namespace DB_FINAL_PROJECT.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
