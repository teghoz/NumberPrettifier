namespace Prettifier.Interfaces;

public interface IPrettifier
{
    string? Pretty(decimal number, string? type = null);
}