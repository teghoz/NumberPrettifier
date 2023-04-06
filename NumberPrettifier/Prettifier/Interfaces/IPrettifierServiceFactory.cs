namespace Prettifier.Interfaces;

public interface IPrettifierServiceFactory
{
    IPrettifier GetPrettifier(string? token);
}