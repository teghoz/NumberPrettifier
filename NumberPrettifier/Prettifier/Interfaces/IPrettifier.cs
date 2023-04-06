namespace Prettifier.Interfaces;

public interface IPrettifier
{
    string? Pretty(double number, string? type = null);
}